myApp.controller('recordCtrl', function ($scope, userInfoData,fileUpload, $modal, $log) {

    $scope.open = function (idCategory, size) {

        $scope.items = [];
        findChild(idCategory, $scope.treedata);

        var modalInstance = $modal.open({
            templateUrl: 'myModalContent.html',
            controller: 'modalCompareCtrl',
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                },
                modal: function () {
                    return $modal;
                },
                mainRecord: function () {
                    return $scope.record;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.sayThankToNote = function (idNote) {
        $('#say').attr("disabled", "disabled");
        getLike("note", idNote);
    }

    $scope.sayThankToFile = function (type, index) {
        switch (type) {
            case 'video':
                $scope.videoLike[index] = true;
                getLike("file",  $scope.videos[index].id);
                break;
            case 'photo':
                $scope.photos[index].like = true;
                getLike("file", $scope.photos[index].id);
                break;
            default:
                $scope.documentLike[index] = true;
                getLike("file", $scope.documents[index].id);
                break;
        }
    }
    $scope.openResource = function (res) {
        $scope.items = [];

        var modalInstance = $modal.open({
            templateUrl: 'resource.html',
            controller: 'resourceCtrl',
            resolve: {
                resource: function () {
                    return res;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    }

    function findChild(idCategory, category) {

        var find = false;
       
        for (var i = 0; i < category.length; i++) {
            if (category[i].id == idCategory) {
                if ((category[i].idNote) && ($scope.record.Id_Note != category[i].idNote))
                {
                    $scope.items.push({
                        name: category[i].label,
                        description: category[i].description,
                        id: category[i].idNote
                    });
                }
                else {
                    find = findChild(idCategory, category[i].children);
                }
                find = true;
            }
            else {
                if (find)
                    break;
                find = findChild(idCategory, category[i].children);
            }
        }
        return find;
    };
   
    function getLike(noteOrFile, id) {
        userInfoData.putLike(noteOrFile, id);
    }
    $scope.addCharacteristic = function (idNote) {

        var modalInstance = $modal.open({
            templateUrl: 'chacteristicModal.html',
            controller: 'modalCharacteristic',
            resolve: {
                note: function () {
                    return $scope.record;
                }
            }
        });
    }

    $scope.addVideo = function () {
        var modalInstance = $modal.open({
            templateUrl: 'addFileModal.html',
            controller: 'addFileCtrl',
            resolve: {
                note: function () {
                    return $scope.record;
                },
                file: function () {
                    return 'video'
                }
            }
        });
    }
    $scope.addDocument = function () {
        var modalInstance = $modal.open({
            templateUrl: 'addFileModal.html',
            controller: 'addFileCtrl',
            resolve: {
                note: function () {
                    return $scope.record;
                },
                file: function () {
                    return 'document'
                }
            }
        });
    }
    $scope.addPhoto = function () {
        var modalInstance = $modal.open({
            templateUrl: 'addFileModal.html',
            controller: 'addFileCtrl',
            resolve: {
                note: function () {
                    return $scope.record;
                },
                file: function () {
                    return 'photo'
                }
            }
        });
    }
    $scope.downloadDoc = function (path, size) {

         fileUpload.getTraffic().success(function (data) {

            if (data >= size)
                window.open(path);
            else
                alert('Traffic limits!')
        })
    }
});
