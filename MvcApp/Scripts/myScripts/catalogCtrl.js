﻿myApp.controller('catalogCtrl', function ($scope, catalogData, userInfoData, noteInfoData, $modal, $log) {

    function getCatalogs() {
        catalogData.getTree().success(function (data) {

            $scope.treedata = init(data);

        });
    } 
    getCatalogs();

     $scope.selectNode = function (value) {

         if (!value.idNote) {
             $('#disc').html(value.description);
             $('#disc').show();
             $('#record').hide();
         }
         else {
             getRecord(value.idNote);
             enableLike(value.idNote, "note");
             CreateByUser($scope.record.Id_User);
             $('#disc').hide();
             $('#record').show();
         }
        }
    
     function init(childNode) {
         
         var child = [];
         for (var i = 0; i < childNode.length; i++) {
             child.push({
                 label: childNode[i].NodeName,
                 description: childNode[i].NodeDescription,
                 id: childNode[i].ID,
                 idNote: childNode[i].IDNote,
                 children: init(childNode[i].ChildNode),
                 collapsed: true
             });
         };
         return child;
     }

    function getRecord(id) {
        catalogData.getRecord(id).success(function (data) {
            $scope.record = data;
        });
    };
   


   $scope.addNote = function (size) {
        var modalInstance = $modal.open({
            templateUrl: 'addNoteModal.html',
            controller: 'addNoteCtrl',
            size: size,
            resolve: {
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
   }
   function CreateByUser(idUser) {
       userInfoData.getUserName(idUser).success(function (data) {
           $scope.creator = data;
       });
   }
   function enableLike(id, noteOrFile) {
       noteInfoData.getLikeEnable(id, noteOrFile).success(function (data) {
           if (data == "true") {
               $('#say').attr("disabled", "disabled");
           }
           else {
               $('#say').removeAttr("disabled");
           }
       });
   }
});