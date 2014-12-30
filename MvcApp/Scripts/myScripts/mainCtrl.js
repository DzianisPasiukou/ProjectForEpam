myApp.controller('mainCtrl', function ($scope) {
    
    $scope.setLogin = function (login) {
        $scope.chatLogin = login;
    };

    $scope.chatLogin = $.cookie('withWhom');

});