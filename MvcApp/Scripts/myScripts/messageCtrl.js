myApp.controller('messageCtrl', function ($scope) {

    $scope.myData = [{ Login: "user", Date: "16.12.2014 21:01", Message: "Hello1" },
                 { Login: "Tiancum", Date: "16.12.2014 20:01", Message: "Hello2" },
                 { Login: "Jacob", Date: "16.12.2014 19:01", Message: "Hello3" },
                 { Login: "Nephi", Date: "16.12.2014 18:01", Message: "Hello4" },
                 { Login: "Moroni", Date: "16.12.2014 17:01", Message: "Hello5" },
                 { Login: "Moroni", Date: "16.12.2014 16:01", Message: "Hello6" },
                 { Login: "Nephi", Date: "16.12.2014 15:01", Message: "Hello7" },
                 { Login: "Moroni", Date: "16.12.2014 14:01", Message: "Hello8" },
                 { Login: "Moroni", Date: "16.12.2014 12:01", Message: "Hello9" },
                 { Login: "Enos", Date: "16.12.2014 11:01", Message: "Hello10" }];

    $scope.chatData = [{ Number: 0, Login: "user", Date: "16.12.2014 21:01", Message: "Hello1" },
                 { Number: 1, Login: "Tiancum", Date: "16.12.2014 20:01", Message: "Hello2" },
                 { Number: 2, Login: "Jacob", Date: "16.12.2014 19:01", Message: "Hello3" }]

    //message click on layout
    $scope.messageClick = function (number) {

        $('#chat-messages').empty();

        $.cookie('isClosed', 'false', { path: '/' });

        var person = $scope.chatData[number].Login;

        var number = 0;

        $.each($scope.chatData, function () {
            if (this.Login == person) {
                $scope.chatData.splice($.inArray(this, $scope.chatData), 1);
            }
        });

        $.each($scope.chatData, function () {
            this.Number = number;
            number++;
        });

        $.cookie('withWhom', person, { path: '/' });

        $scope.chatLogin = person;

        console.log($scope.chatLogin);

        $('#allChat').show();

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
                var jsonEmployees = JSON.stringify(data);//converting array into json string   
                $.cookie("messages", jsonEmployees, { path: '/' });//storing it in a cookie

                $.each(data, function () {
                    $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + this.Date + '</small> <strong class="pull-right primary-font">' + this.Login_Sender + '</strong> </div><p>' + this.Text + ' </p></div></li>');
                });
            }
        });

        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);

    };

    //click on chat page
    $scope.showChat = function (login) {

        $('#chat-messages').empty();

        $.cookie('isClosed', 'false', { path: '/' });

        var person = login;

        $.cookie('withWhom', person, { path: '/' });

        $scope.chatLogin = person;

        $('#allChat').show();

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
                var jsonEmployees = JSON.stringify(data);//converting array into json string   
                $.cookie("messages", jsonEmployees, { path: '/' });//storing it in a cookie

                $.each(data, function () {
                    $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + this.Date + '</small> <strong class="pull-right primary-font">' + this.Login_Sender + '</strong> </div><p>' + this.Text + ' </p></div></li>');
                });
            }
        });

        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
    };

    $scope.chatLogin = $.cookie('withWhom');

    $(document).ready(function () {
        var hidden = $.cookie('hidden');

        var isClosed = $.cookie('isClosed');

        if (isClosed == 'false') {

            var empString = $.cookie("messages");//retrieving data from cookie
            var data = $.parseJSON(empString);//converting "empString" to an array.

            $.each(data, function () {
                $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + this.Date + '</small> <strong class="pull-right primary-font">' + this.Login_Sender + '</strong> </div><p>' + this.Text + ' </p></div></li>');
            });

            $('#allChat').show();

            if (hidden == 'true') {
                $('#hiddenChat').hide();
                $.cookie('isReload', "true", { path: '/' });
            }
            else {
                $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
            }
        }

    });

    //Vlad SignalR

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