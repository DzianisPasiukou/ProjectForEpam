
    var chat = $.connection.messageHub;
    var login = $('#userLogin').text();
    var count = 0;

    $.connection.hub.start().done(function () {
        chat.server.registr(login);
    });

    //chat.client.addToPageAll = function (senderLogin, message, date) {
    //    $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> ' + date + '</small> <strong class="pull-right primary-font">' + senderLogin + '</strong> </div><p>' + message + ' </p></div></li>');
    //};
    chat.client.addToPage = function (senderLogin,message,date) {
        $('#chat-messages').append('<li class="right clearfix"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><small class=" text-muted"><i class="fa fa-clock-o fa-fw"></i> '+date+'</small> <strong class="pull-right primary-font">'+senderLogin+'</strong> </div><p>'+message+' </p></div></li>');
    };
    chat.client.send = function (senderLogin, message, date) {
       
        $('#chat-messages').append(' <li class="left clearfix"><span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff" alt="User Avatar" class="img-circle" /></span><div class="chat-body clearfix"><div class="header"><strong class="primary-font">'+senderLogin+'</strong><small class="pull-right text-muted"><i class="fa fa-clock-o fa-fw"></i>'+date+'</small></div><p>'+message+'</p></div></li>');
       // UpdateCount();

       // if ($('#dropMessages').children().length == 6) {
            
       //     $('#dropMessages').find('li:first').next('li').next('li').next('li').remove();        
       // }     
    };
    $.connection.hub.start().done(function () {
        $('#btn-chat').click(function () {
           var message = $('#btn-input').val();
           chat.server.sendTo(login,'user', message);
        });
       
    });
    function UpdateCount() {
        count++;
        $('#count').text('+'+count);
    };