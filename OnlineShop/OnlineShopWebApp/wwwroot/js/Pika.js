const topFace = document.getElementById('topFace');
let isAlertShown = false;
topFace.addEventListener('mousedown', function () { topFace.classList.add('active');});
topFace.addEventListener('transitionend', function (event) {
    if (event.propertyName === 'transform' && !isAlertShown) { 
        isAlertShown = true; 
        alert("Ваша посылка отправлена!");

        setTimeout(() => { window.location.href = "/"; }, 2000); 
    }
});

topFace.addEventListener('mouseup', function () {
    topFace.classList.remove('active');
});
