function toggleTopNavModel() {
    document.getElementById('topnav').classList.toggle('responsive');
}

function refreshContent(name) {
    fetch("giraffe-app/" + name)
        .then(data => data.text().then(result => document.getElementById('content').innerHTML = result))
        .catch(error => console.log(error));

    Array.from(document.getElementsByClassName('nav-active')).forEach(e => e.classList.remove('nav-active'));
    document.getElementById(`topnav-${name}`).classList.add('nav-active');
}