myApp.controller('usersInformationCtrl', function ($scope, $http, $modal) {

    $scope.isLoginSort = false;
    $scope.isIsActiveSort = false;

    $scope.loginSort = function () {

        $scope.users.sort(function (a, b) {

            if ($scope.isLoginSort == false) {
                $scope.isLoginSort = true;
                $scope.isIsActiveSort = false;
                if (a.Login < b.Login) return -1;
                if (a.Login > b.Login) return 1;
                return 0;
            }
            else {
                $scope.isLoginSort = false;
                if (a.Login < b.Login) return 1;
                if (a.Login > b.Login) return -1;
                return 0;
            }
        });
    };

    $scope.isActiveSort = function () {

        $scope.users.sort(function (a, b) {

            if ($scope.isIsActiveSort == false) {
                $scope.isLoginSort = false;
                $scope.isIsActiveSort = true;
                if (a.IsActive < b.IsActive) return 1;
                if (a.IsActive > b.IsActive) return -1;
                return 0;
            }
            else {
                $scope.isIsActiveSort = false;
                if (a.IsActive < b.IsActive) return -1;
                if (a.IsActive > b.IsActive) return 1;
                return 0;
            }
        });

    };

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


    $scope.edit = function (login) {

        $.each($scope.users, function () {
            if (this.Id_Group == 1) {
                this.Id_Group = "Admin";
            }
            if (this.Id_Group == 2) {
                this.Id_Group = "Student";
            }
        });

        var modalInstance = $modal.open({
            templateUrl: 'editUserModal.html',
            controller: 'editUserCtrl',
            resolve: {
                user: function () {

                    var u;

                    angular.forEach($scope.users, function (item) {
                        if (item.Login == login) {
                            u = item;
                        }
                    });

                    return u;
                },

                groups: function () {

                    var group = [{ Group: 'Admin' },
                            { Group: 'Student' }];

                    return group;
                }
            }
        });
    }

    $scope.delete = function (login) {

        var modalInstance = $modal.open({
            templateUrl: 'deleteUserModal.html',
            controller: 'deleteUserCtrl',
            resolve: {
                userLogin: function () {
                    return login;
                },
                fullName: function () {

                    var fullName;

                    angular.forEach($scope.users, function (item) {
                        if (item.Login == login) {
                            fullName = item.Name + " " + item.Surname;
                        }
                    });

                    return fullName;
                }
            }
        });

        modalInstance.result.then(function () {

            angular.forEach($scope.users, function (item) {
                if (item.Login == login) {
                    $scope.users.splice($.inArray(item, $scope.users), 1);
                }
            });

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

            $scope.currentPage = 0;
            $scope.pageSize = 10;
            $scope.numberOfPages = function () {
                return Math.ceil($scope.users.length / $scope.pageSize);
            }

            $scope.$apply();
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