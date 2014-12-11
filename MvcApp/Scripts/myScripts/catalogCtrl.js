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

     $scope.selectNode = function (value) {

         if (!value.idRecord) {
             $('#disc').html(value.description);
             $('#disc').show();
             $('#record').hide();
         }
         else {
             getRecord(value.idRecord);
             $('#disc').hide();
             $('#record').show();
         }
        }
    function getTree() {
        var childNode = [];
        for (var i = 0; i < $scope.catalogs.ChildNode.length; i++) {

            childNode.push({
                "label": $scope.catalogs.ChildNode[i].NodeName,
                "id": $scope.catalogs.ChildNode[i].ID,
                "children": [],
                "description": $scope.catalogs.ChildNode[i].NodeDescription,
                "collapsed": true
            });
            for (var j = 0; j < $scope.catalogs.ChildNode[i].ChildNode.length; j++) {
                childNode[i].children.push({
                    "label": $scope.catalogs.ChildNode[i].ChildNode[j].NodeName,
                    "id": $scope.catalogs.ChildNode[i].ChildNode[j].ID,
                    "children": [],
                    "description": $scope.catalogs.ChildNode[i].ChildNode[j].NodeDescription,
                    "collapsed": true
                });
                for (var k = 0; k < $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode.length; k++) {
                    childNode[i].children[j].children.push({
                        "label": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].NodeName,
                        "id": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].ID,
                        "children": [],
                        "description": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].NodeDescription,
                        "idRecord": $scope.catalogs.ChildNode[i].ChildNode[j].ChildNode[k].IdRecord,
                        "collapsed": true
                    });
                }
            }
        }


        $scope.treedata =
    [
        {
            "label": $scope.catalogs.NodeName, "id": $scope.catalogs.ID, "children": childNode,
            "description": $scope.catalogs.NodeDescription, "collapsed": true
        }
    ];
    }
    function getRecord(id) {
        catalogData.getRecord(id).success(function (data) {
            $scope.record = data;
        });
    };
});