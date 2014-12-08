myApp.controller('catalogCtrl', function ($scope, catalogData) {

    $scope.catalogs = {};

    function getCatalogs() {
        catalogData.getTree().success(function (data) {
            $scope.catalogs = data;

            getTree();

            if(!$scope.$$phase)
            $scope.$apply();
        });
    } 
    getCatalogs();
   
    function getTree() {
        var childNode = [];
        for (var i = 0; i < $scope.catalogs.ChildNode.length; i++) {

            childNode.push({
                "label": $scope.catalogs.ChildNode[i].NodeName,
                "id": $scope.catalogs.ChildNode[i].ID,
                "children": [],
                "description": $scope.catalogs.ChildNode[i].NodeDescription
                
            });
            for (var j = 0; j < $scope.catalogs.ChildNode[i].ChildNode.length; j++) {
                childNode[i].children.push({
                    "label": $scope.catalogs.ChildNode[i].ChildNode[j].NodeName,
                    "id": $scope.catalogs.ChildNode[i].ChildNode[j].ID,
                    "children": [],
                    "description": $scope.catalogs.ChildNode[i].ChildNode[j].NodeDescription
                });
                for (var k = 0; k < $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode.length; k++) {
                    childNode[i].children[j].children.push({
                        "label": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].NodeName,
                        "id": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].ID,
                        "children": [],
                        "description": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].NodeDescription,
                        "idRecord": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].IdRecord
                    });
                }
            }
        }


        $scope.treedata =
    [
        {
            "label": $scope.catalogs.NodeName, "id": $scope.catalogs.ID, "children": childNode,
            "description": $scope.catalogs.NodeDescription
        }
    ];

        $scope.selectNode = function (value) {

            if (!value.idRecord)
                $('#disc').html(value.description);
            else {

                //$http.get("/CatalogView/Details?id=" + value.idRecord).success(function (data) {


                $.ajax({
                    url: "/CatalogView/Details?id=" + value.idRecord,
                    type: 'GET',
                    success: function (data) {
                        $('#disc').html(data);
                    }
                })
            }
        }
       
    }
});