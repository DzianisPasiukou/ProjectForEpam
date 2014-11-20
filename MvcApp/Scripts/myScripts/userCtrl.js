myApp.controller('userCtrl', function ($scope, usersData) {
    usersData.getUsers().success(function (data) {
        $scope.users = data;
    });
    $scope.roleList = {
        "roleName": "catalogs", "roleId": "catalogsId", "children": [

        ]
    };
});