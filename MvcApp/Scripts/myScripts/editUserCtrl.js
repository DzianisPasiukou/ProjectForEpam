myApp.controller('editUserCtrl', ['$scope', '$modalInstance', 'user', 'groups', function ($scope, $modalInstance, user, groups) {

    var jsonUser = JSON.stringify(user);
    $.cookie("user", jsonUser, { path: '/' });

    $scope.user = user;
    $scope.groups = groups;
    $scope.userGroup = user.Id_Group;

    $scope.ok = function () {
        $.ajax({
            url: '/api/Users/?login=' + $scope.user.Login + "&name=" + $scope.user.Name + "&surname=" + $scope.user.Surname + "&email=" + $scope.user.Email + "&group=" + $scope.user.Id_Group,
            type: "PUT",
        });
        $modalInstance.close();
    };

    $scope.changeGroup = function (group) {
        $scope.userGroup = group;
        $scope.user.Id_Group = group;
    };

    $scope.cancel = function () {
        var empString = $.cookie("user");
        var cookieUser = $.parseJSON(empString);
        $scope.user.Name = cookieUser.Name;
        $scope.user.SurName = cookieUser.SurName;
        $scope.user.Email = cookieUser.Email;
        $scope.user.Id_Group = cookieUser.Id_Group;

        $modalInstance.dismiss();
    };

}])
.controller('deleteUserCtrl', ['$scope', '$modalInstance', 'userLogin', 'fullName', function ($scope, $modalInstance, userLogin, fullName) {

    $scope.fullName = fullName;

    $scope.ok = function () {
        $.ajax({
            url: '/api/Users/?login=' + userLogin,
            type: "DELETE",
            success: function (data) {
                if (data) {
                    $modalInstance.close("Ok");
                } else {
                    $modalInstance.close("Not delete");
                }
            }
        });

    };

    $scope.cancel = function () {
        $modalInstance.dismiss("Close");
    };
}]);