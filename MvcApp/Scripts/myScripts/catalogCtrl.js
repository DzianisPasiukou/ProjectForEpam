myApp.controller('catalogCtrl', function ($scope, catalogData, $modal, $log) {


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
            CreateByUser($scope.record.Id_User);
            $('#disc').hide();
            $('#record').show();
        }
    }
    function CreateByUser(idUser) {
        catalogData.getUserName(idUser).success(function (data) {
            $scope.creator = data;
        });
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



    //Valik

    $scope.myData = [{ Id: 1, User: "Moroni", Date: "16.12.2014 21:01", Message: "Hello1", Link: "~/Account/Chat" },
                 { Id: 2, User: "Tiancum", Date: "16.12.2014 20:01", Message: "Hello2", Link: "~/Account/Chat" },
                 { Id: 3, User: "Jacob", Date: "16.12.2014 19:01", Message: "Hello3", Link: "~/Account/Chat" },
                 { Id: 4, User: "Nephi", Date: "16.12.2014 18:01", Message: "Hello4", Link: "~/Account/Chat" },
                 { Id: 5, User: "Moroni", Date: "16.12.2014 17:01", Message: "Hello5", Link: "~/Account/Chat" },
                 { Id: 6, User: "Moroni", Date: "16.12.2014 16:01", Message: "Hello6", Link: "~/Account/Chat" },
                 { Id: 7, User: "Nephi", Date: "16.12.2014 15:01", Message: "Hello7", Link: "~/Account/Chat" },
                 { Id: 8, User: "Moroni", Date: "16.12.2014 14:01", Message: "Hello8", Link: "~/Account/Chat" },
                 { Id: 9, User: "Moroni", Date: "16.12.2014 12:01", Message: "Hello9", Link: "~/Account/Chat" },
                 { Id: 10, User: "Enos", Date: "16.12.2014 11:01", Message: "Hello10", Link: "~/Account/Chat" }];

    $scope.chatData = [{ Id: 0, User: "Moroni", Date: "16.12.2014 21:01", Message: "Hello1" },
                 { Id: 1, User: "Tiancum", Date: "16.12.2014 20:01", Message: "Hello2" },
                 { Id: 2, User: "Jacob", Date: "16.12.2014 19:01", Message: "Hello3" }]

    $scope.messageClick = function (number) {

        $.cookie('isClosed', 'false', { path: '/' });

        var person = $scope.chatData[number].User;

        $.cookie('withWhom', person, { path: '/' });

        $scope.chatLogin = person;

        $('#allChat').show();

        var hidden = $.cookie('hidden');

        if (hidden == 'true') {
            $('#hiddenChat').show();
            $.cookie('hidden', 'false', { path: '/' });
        }
        else {
            $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
        }

    };

    $scope.chatLogin = $.cookie('withWhom');

    $scope.lol = function (id) {
        alert(id);
        console.log(id);
    };

    $(document).ready(function () {
        var hidden = $.cookie('hidden');

        var isClosed = $.cookie('isClosed');

        if (isClosed == 'false') {

            $('#allChat').show();

            if (hidden == 'true') {
                $('#hiddenChat').hide();
                $.cookie('isReload', "true", { path: '/' });
            }
            else {
                $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
            }
        }

    });


});

$('#close').click(function () {
    $('#allChat').hide();
    $.cookie('isClosed', 'true', { path: '/' });
});

$('#minimize').click(function () {

    var isHidden = $.cookie('hidden');

    if (isHidden == 'false') {

        a = $('#hiddenChat').html();
        $('#hiddenChat').hide();

        $.cookie('hidden', 'true', { path: '/' });
    }
    else {

        $('#hiddenChat').show();
        var isReload = $.cookie('isReload');
        if (isReload == 'true') {

            $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
            $.cookie('isReload', 'false', { path: '/' });
        }

        $.cookie('hidden', 'false', { path: '/' });
        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
    }
});