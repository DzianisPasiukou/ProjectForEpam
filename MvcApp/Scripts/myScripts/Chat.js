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

var a;

$('#minimize').click(function () {

    var isHidden = $.cookie('hidden');

    if (isHidden == 'false') {

        a = $('#hiddenChat').html();
        $('#hiddenChat').empty();

        $.cookie('hidden', 'true', { path: '/' });
    }
    else {
        $('#hiddenChat').prepend(a);
        a = "";

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

            $('#hiddenChat').prepend('<div class="panel-body"> <ul class="chat"><li class="left clearfix"><span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><strong class="primary-font">Jack Sparrow</strong><small class="pull-right text-muted"><i class="fa fa-clock-o fa-fw"></i> 12 mins ago</small></div><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales.</p></div></li><li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> 13 mins ago</small><strong class="pull-right primary-font">Bhaumik Patel</strong></div><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales.</p></div></li></ul></div><!-- /.panel-body --><div class="panel-footer"><div class="input-group"><input id="btn-input" type="text" class="form-control input-sm" placeholder="Type your message here..." /><span class="input-group-btn"><button class="btn btn-warning btn-sm" id="btn-chat">Send</button></span></div></div>');

            $.cookie('isReload', 'false', { path: '/' });

            console.log('isReload - false');
        }

        $.cookie('hidden', 'false');
    }
});

$(function () {
    var b = $.cookie('hidden');

    if (b == 'true') {
        $('#hiddenChat').empty();
        $.cookie('isReload', "true", { path: '/' });
    }

    console.log(b);

});