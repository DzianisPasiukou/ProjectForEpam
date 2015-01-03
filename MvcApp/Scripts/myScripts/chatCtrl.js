myApp.controller('chatCtrl', ['$scope', '$modal', function ($scope, $modal) {

    $scope.prevClick = function () {
        if ($scope.currentPage == 0) {
            return;
        }
        else {
            $scope.currentPage -= 1;
        }
    }

    $scope.nextClick = function () {
        if ($scope.currentPage > ($scope.contacts.length / $scope.pageSize) - 1) {
            return;
        }
        else {
            $scope.currentPage += 1;
        }
    }

    $scope.addContact = function () {
        var newContact = $('#addContact').val();
        $.ajax({
            url: '/api/Message/?login=' + $('#userLogin').text() + '&userLogin=' + newContact,
            type: "POST",
            success: function (data) {
                $scope.contacts.push(data);
                $scope.$apply();
            }
        });
    };

    $.ajax({
        url: '/api/Message/?login=' + $('#userLogin').text(),
        type: "GET",
        success: function (data) {
            $scope.contacts = data;
            $scope.currentPage = 0;
            $scope.pageSize = 10;
            $scope.numberOfPages = function () {
                return Math.ceil($scope.contacts.length / $scope.pageSize);
            }

            $scope.$apply();
        }
    });

    $scope.chat = function (login) {

        $scope.setLogin(login);

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

        var senderLogin = $('#userLogin').text();

        $.ajax({
            url: '/api/Message',
            data: "sender=" + senderLogin + "&recipient=" + login,
            success: function (data) {

                angular.forEach(data, function (item) {
                    if (item.Login_Sender == senderLogin) {
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
}])
.controller('contactDeleteCtrl', ['$scope', '$modalInstance', 'login', 'userLogin', function ($scope, $modalInstance, login, userLogin) {

    $scope.ok = function () {
        $.ajax({
            url: '/api/Message/?login=' + login + '&userLogin=' + userLogin,
            type: "DELETE",
        });
        $modalInstance.close("Ok");
    };

    $scope.cancel = function () {
        $modalInstance.dismiss("Close");
    };

}]);