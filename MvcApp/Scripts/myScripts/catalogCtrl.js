myApp.controller('catalogCtrl', ['$scope', 'catalogData', 'userInfoData', 'noteInfoData', '$modal', '$log', function ($scope, catalogData, userInfoData, noteInfoData, $modal, $log) {

    $scope.treedata = [];

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
            getInfoFromNote(value.idNote);
            enableLike(value.idNote, "note");
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
                collapsed: true,
                noLeaf: !childNode[i].IDNote
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
    function enableLike(id, noteOrFile) {
        userInfoData.getLikeEnable(id, noteOrFile).success(function (data) {
            if (data.Id) {
                $('#say').attr("disabled", "disabled");
            }
            else {
                $('#say').removeAttr("disabled");
            }
        });
    }

    function fileLike(id, videoOrDocument) {

        if (videoOrDocument == 'video') {
            userInfoData.getLikeEnable(id, 'file').success(function (data) {
                if (data.Id) {
                    $scope.videoLike.push(true);
                }
                else {
                    $scope.videoLike.push(false);
                }
            });
        }
        if (videoOrDocument == 'document') {
            userInfoData.getLikeEnable(id, 'file').success(function (data) {
                if (data.Id) {
                    $scope.documentLike.push(true);
                }
                else {
                    $scope.documentLike.push(false);
                }
            });
        }
    }


    function getInfoFromNote(id) {
        noteInfoData.getNoteInfo(id).success(function (data) {

            $scope.myInterval = 5000;

            $scope.photos = [];
            $scope.videos = [];
            $scope.documents = [];
            $scope.characteristics = [];
            $scope.videoLike = [];
            $scope.documentLike = [];

            for (var i = 0; i < data.Files.length; i++) {


                switch (data.Files[i].Type) {
                    case 'Видео':
                        $scope.videos.push({
                            id: data.Files[i].Id_File,
                            path: data.Files[i].Path,
                            user: data.Files[i].Login,
                            size: data.Files[i].Size,
                            description: data.Files[i].Description,
                        });
                        fileLike(data.Files[i].Id_File, 'video');
                        break;
                    case 'Фото':
                        $scope.photos.push({
                            id: data.Files[i].Id_File,
                            path: data.Files[i].Path,
                            user: data.Files[i].Login,
                            size: data.Files[i].Size,
                            description: data.Files[i].Description,
                        });
                        break;
                    default:
                        $scope.documents.push({
                            id: data.Files[i].Id_File,
                            path: data.Files[i].Path,
                            user: data.Files[i].Login,
                            size: data.Files[i].Size,
                            description: data.Files[i].Description,
                            type: data.Files[i].Type,
                        });
                        fileLike(data.Files[i].Id_File, 'document');
                        break;
                }
            }

            for (var i = 0; i < data.Characteristics.length; i++) {
                $scope.characteristics.push({
                    id: data.Characteristics[i].Id_Characteristic,
                    name: data.Characteristics[i].Name,
                    value: data.CharacteristicsOfNote[i].Value
                });
            }
        });
    }
}]);