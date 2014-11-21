myApp.controller('catalogCtrl', function ($scope, catalogData) {
    catalogData.catalogCtrl().success(function (data) {
        $scope.catalogs = data;
    });
    $scope.roleList = {
        "roleName": "catalogs", "roleId": "catalogsId", "children": [
            $scope.data
        ]
    };
});