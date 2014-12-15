
    var chat = $.connection.messageHub;
    var userName = $('#userName').text();

    $.connection.hub.start().done(function () {
        chat.server.registr(userName)
    });

    chat.client.addToPage = function (sender,message,date) {
        $('#dropMessages').append('<li><a href="#"><div><strong>'+sender+'</strong><span class="pull-right text-muted"><em>'+date+'</em></span></div><div>'+message+'</div></a></li> ');
    };
    $.connection.hub.start().done(function () {
        $('#okbtn').click(function () {        
            chat.server.sendAll(userName,'lal','');
            $('#dropMessages').focus();
        });
    });  