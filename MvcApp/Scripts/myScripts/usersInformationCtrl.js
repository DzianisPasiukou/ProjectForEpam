myApp.controller('usersInformationCtrl', function ($scope, $http) {

    $scope.prevClick = function () {
        if ($scope.currentPage == 0) {
            return;
        }
        else {
            $scope.currentPage -= 1;
        }
    }

    $scope.nextClick = function () {
        if ($scope.currentPage > ($scope.users.length / $scope.pageSize) - 1) {
            return;
        }
        else {
            $scope.currentPage += 1;
        }
    }

    $scope.showInformation = function (login) {

    };

    $scope.loginSort = function () {

        $scope.users.sort(function (a, b) {
            if (a.Login < b.Login) return -1;
            if (a.Login > b.Login) return 1;
            return 0;
        });

    };

    $scope.isActiveSort = function () {

        $scope.users.sort(function (a, b) {
            if (a.IsActive < b.IsActive) return 1;
            if (a.IsActive > b.IsActive) return -1;
            return 0;
        });

    };

    $scope.checkClick = function (login, isActive) {

        $.ajax({
            url: '/api/Users/?login=' + login + "&isActive=" + isActive,
            type: "PUT",
        });

    };

    $.ajax({
        url: '/api/Users',
        type: "GET",
        success: function (data) {

            $.each(data, function () {
                if (this.Id_Group == 1) {
                    this.Id_Group = "Admin";
                } else {
                    this.Id_Group = "Student";
                }
            });

            $scope.users = data;

            var b = $http.get('/api/Users');

            $scope.currentPage = 0;
            $scope.pageSize = 10;
            $scope.numberOfPages = function () {
                return Math.ceil($scope.users.length / $scope.pageSize);
            }
        }
    });
});

myApp.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        if (input == undefined) {
            return;
        }
        return input.slice(start);
    }
});