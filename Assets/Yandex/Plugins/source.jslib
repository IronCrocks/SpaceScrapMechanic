mergeInto(LibraryManager.library, {

    Hello: function () {
        window.alert("Hello, world!");
    },

    SaveExtern: function (data) {
        var dataString = UTF8ToString(data);
        var myObj = JSON.parse(dataString);
        player.setData(myObj);

    },

    LoadExtern: function () {
        player.getData().then(data => {
            const myJson = JSON.stringify(data);
            myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJson);
        });
    },

});