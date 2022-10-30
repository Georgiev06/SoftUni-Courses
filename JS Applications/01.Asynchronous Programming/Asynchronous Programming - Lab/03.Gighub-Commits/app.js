function loadCommits() {
    // Try it with Fetch API
    console.log('TODO...');
    let username = document.getElementById('username').value;
    let repository = document.getElementById('repo').value;
    let commits = document.getElementById('commits');

    fetch(`https://api.github.com/repos/${username}/${repository}/commits`)
	.then((response) => {
		if (response.ok == false) {
			console.log(response);
			throw new Error(`Error: ${response.status} (Not Found)`);
		}
		
		return response.json();
	})
	.then((data) => {		
		commits.innerHTML = '';

		for (const item of data) {
			let li = document.createElement('li');
            li.textContent = `${item.commit.author.name}: ${item.commit.message}`

			commits.appendChild(li);
		}
	})
	.catch((error) => console.error(error))
}