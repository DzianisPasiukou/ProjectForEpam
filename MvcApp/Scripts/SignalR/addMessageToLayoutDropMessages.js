
    var chat = $.connection.messageHub;
    var userName = $('#userName').text();
    var count = 0;

    $.connection.hub.start().done(function () {
        chat.server.registr(userName)
    });

    chat.client.addToPage = function (sender,message,date) {
        $('#dropMessages').prepend('<li><a href="#"><div><strong>' + sender + '</strong><span class="pull-right text-muted"><em>' + date + '</em></span></div><div>' + message + '</div></a></li> ');
        UpdateCount();

        if ($('#dropMessages').children().length == 6) {
            
            $('#dropMessages').find('li:first').next('li').next('li').next('li').remove();        
        }     
    };
    $.connection.hub.start().done(function () {
        $('#okbtn').click(function () {        
            chat.server.sendAll(userName,'seven77','');
            $('#dropMessages').focus();
        });
       
    });
    function UpdateCount() {
        count++;
        $('#count').text('+'+count);
    };