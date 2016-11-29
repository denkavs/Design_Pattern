'use strict';

var IFrameObj;

(function () {
    document.getElementsByClassName('jsonp')[0].onclick = function (e) {

        var newScript = document.createElement('script');
        newScript.src = 'jsonpScript.js';
        var firstScript = document.getElementsByTagName('script')[0];
        firstScript.parentNode.insertBefore(newScript, firstScript);
    };

    document.getElementsByClassName('imagebeacon')[0].onclick = function (e) {

        var img = document.createElement('img');
        img.src = 'imgBeaconScript.js';
    };

    document.getElementsByClassName('iframe')[0].onclick = function (e) {

        var URL = 'iframeServer.html';
        if (IFrameObj === undefined)
        {
            var iframe = document.createElement('iframe');
            iframe.style.width = '0px';
            iframe.style.height = '0px';
            iframe.style.border = '0px';
            //iframe.src = 'iframeServer.html';

            var footer = document.getElementById('footerContent');
            IFrameObj = footer.appendChild(iframe);
        }

        var IFrameDoc = IFrameObj.contentDocument;
        IFrameDoc.location.replace(URL);
        //firstScript.parentNode.insertBefore(newScript, firstScript);
    };
}());

function processDataFromThirdPartServer(data) {
    if(data !== undefined && typeof data === 'object')
    {
        var name = data.name;
        alert(name);
    }
};