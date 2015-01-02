myApp.controller('messageCtrl', function ($scope) {

    $scope.chatData = [{ Number: 0, Login: "user", Date: "16.12.2014 21:01", Message: "Hello1" }];

    //message click on layout

    $scope.messageClick = function (number) {

        $('#chat-messages').empty();

        $.cookie('isClosed', 'false', { path: '/' });

        var person = $scope.chatData[number].Login;
        var number = 0;

        angular.forEach($scope.chatData, function (item) {
            item.Number = number;
            number++;
        });

        $.cookie('withWhom', person, { path: '/' });

        $scope.chatLogin = person;

        console.log($scope.chatLogin);

        $('#allChat').show();

        console.log('after show');

        var hidden = $.cookie('hidden');

        if (hidden == 'true') {
            $('#hiddenChat').show();
            $.cookie('hidden', 'false', { path: '/' });
        }
        else {
            $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
        }

        var login = $('#userLogin').text();

        $.ajax({
            url: '/api/Message',
            data: "sender=" + login + "&recipient=" + person,
            success: function (data) {

                angular.forEach(data, function (item) {
                    if (item.Login_Sender == login) {
                        $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + item.Date + '</small> <strong class="pull-right primary-font">' + item.Login_Sender + '</strong> </div><p>' + item.Text + ' </p></div></li>');
                    }
                    else {
                        $('#chat-messages').append(' <li class="left clearfix"><span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><strong class="primary-font">' + item.Login_Sender + '</strong><small class="pull-right text-muted"><i class="fa fa-clock-o fa-fw"></i>' + item.Date + '</small></div><p>' + item.Text + '</p></div></li>');

                    }
                });
                $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
            }
        });

    };

    //click on chat page

    //$scope.chatLogin = $.cookie('withWhom');

    $(document).ready(function () {
        var hidden = $.cookie('hidden');

        var isClosed = $.cookie('isClosed');

        var person = $.cookie('withWhom');

        if (isClosed == 'false') {

            $.ajax({
                url: '/api/Message',
                data: "sender=" + $('#userLogin').text() + "&recipient=" + person,
                success: function (data) {

                    angular.forEach(data, function (item) {
                        if (item.Login_Sender == $('#userLogin').text()) {
                            $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + item.Date + '</small> <strong class="pull-right primary-font">' + item.Login_Sender + '</strong> </div><p>' + item.Text + ' </p></div></li>');
                        }
                        else {
                            $('#chat-messages').append(' <li class="left clearfix"><span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><strong class="primary-font">' + item.Login_Sender + '</strong><small class="pull-right text-muted"><i class="fa fa-clock-o fa-fw"></i>' + item.Date + '</small></div><p>' + item.Text + '</p></div></li>');

                        }
                    });

                    $('#allChat').show();

                    if (hidden == 'true') {
                        $('#hiddenChat').hide();
                        $.cookie('isReload', "true", { path: '/' });
                    }
                    else {
                        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
                    }

                    $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
                }
            });

        }

    });

    // begin SignalR
    var chat = $.connection.messageHub;
    var count = 0;

    $.connection.hub.start().done(function () {
        $('#btn-chat').click(function () {
            var message = $('#btn-input').val();
            chat.server.sendTo($scope.chatLogin, message);
        });
    });
    chat.client.addToPage = function (senderLogin, message, date) {
        $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + date + '</small> <strong class="pull-right primary-font">' + senderLogin + '</strong> </div><p>' + message + ' </p></div></li>');
        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
    };
    chat.client.send = function (senderLogin, message, date) {
        if (senderLogin == $scope.chatLogin) {
            $('#chat-messages').append(' <li class="left clearfix"><span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><strong class="primary-font">' + senderLogin + '</strong><small class="pull-right text-muted"><i class="fa fa-clock-o fa-fw"></i>' + date + '</small></div><p>' + message + '</p></div></li>');
            $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
        }
        else {
            count++;
            $('#message-count').text('+' + count);
            $.each($scope.chatData, function () {
                if (this.Number == 2) {
                    $scope.chatData.splice($.inArray(this, $scope.chatData), 1);
                }
            });
            var number = 1;
            angular.forEach($scope.chatData, function (item) {
                item.Number = number;
                number++;
            });

            $scope.chatData.push({ Number: 0, Login: senderLogin, Date: date, Message: message });
            $scope.$apply();
        }
    };
    // end SignalR
});

$('#close').click(function () {
    $('#allChat').hide();
    $.cookie('isClosed', 'true', { path: '/' });
});

$('#minimize').click(function () {

    var isHidden = $.cookie('hidden');

    if (isHidden == 'false') {

        a = $('#hiddenChat').html();
        $('#hiddenChat').hide();

        $.cookie('hidden', 'true', { path: '/' });
    }
    else {

        $('#hiddenChat').show();
        var isReload = $.cookie('isReload');
        if (isReload == 'true') {

            $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
            $.cookie('isReload', 'false', { path: '/' });
        }

        $.cookie('hidden', 'false', { path: '/' });
        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
    }
});