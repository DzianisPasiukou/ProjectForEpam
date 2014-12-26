var app = angular.module('Chat', ['ngGrid']);
app.controller('MyCtrl', function ($scope, $http) {
    $scope.myData = [{ Id: 1, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 2, User: "Tiancum", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 3, User: "Jacob", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 4, User: "Nephi", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 5, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 6, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 7, User: "Nephi", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 8, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 9, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 10, User: "Enos", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" }];


    $scope.lol = function (id) {
        alert(id);
        console.log(id);
    };
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

            //request to server (ajax)

            //var url = "/api/Message/";

            //var array;

            //$.ajax({
            //    url: '/api/Message',
            //    success: function () {
            //        alert('Load was performed.');
            //    }
            //});

            //console.log(array);

            //$('#hiddenChat').append('<div class="panel-body" id="scroll"><ul class="chat" id="chat-messages"></ul></div><!-- /.panel-body --><div class="panel-footer"><div class="input-group"><input id="btn-input" type="text" class="form-control input-sm" placeholder="Type your message here..." /><span class="input-group-btn"><button class="btn btn-warning btn-sm" id="btn-chat">Send</button></span></div></div>');
            $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
            $.cookie('isReload', 'false', { path: '/' });

            console.log('isReload - false');
        }

        $.cookie('hidden', 'false', { path: '/' });
        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
    }
});

$('#close').click(function () {
    $('#allChat').hide();
});

$(function () {
    var b = $.cookie('hidden');

    if (b == 'true') {
        $('#hiddenChat').hide();
        $.cookie('isReload', "true", { path: '/' });
    }
    else {
        $("#scroll").scrollTop($("#scroll")[0].scrollHeight);
    }

    console.log(beer);

});