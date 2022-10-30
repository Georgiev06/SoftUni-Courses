function loadRepos() {
   let url = 'https://api.github.com/users/testnakov/repos';
   const httpRequest = new XMLHttpRequest();

   // httpRequest.onreadystatechange = function () {
   //    if (httpRequest.readyState == 4) {
   //       document.getElementById("res").textContent = httpRequest.responseText;
   //    }
   // };

   httpRequest.addEventListener('readystatechange', function () {
      if (httpRequest.readyState == 4) {
         document.getElementById("res").textContent = httpRequest.responseText;
      }
   });

   httpRequest.open("GET", url);
   httpRequest.send();
}