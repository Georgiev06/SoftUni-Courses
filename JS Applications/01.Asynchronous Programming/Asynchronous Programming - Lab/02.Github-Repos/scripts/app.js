function loadRepos() {
	console.log("TODO...");

	let username = document.getElementById('username').value;
	let repos = document.getElementById('repos');
	
	//const url = `https://api.github.com/users/${username}/repos`
	
	fetch(`https://api.github.com/users/${username}/repos`)
	.then((response) => {
		if (response.ok == false) {
			console.log(response);
			throw new Error(`${response.status} ${response.statusText}`);
		}
		
		return response.json();
	})
	.then((data) => {		

		repos.innerHTML = '';

		for (const item of data) {
			let li = document.createElement('li');
			let a = document.createElement('a');
			a.href = item.html_url;
			a.textContent = item.full_name;

			li.appendChild(a);
			repos.appendChild(li);
		}
		
		//console.log(data);
	})
	.catch((error) => console.error(error))
}