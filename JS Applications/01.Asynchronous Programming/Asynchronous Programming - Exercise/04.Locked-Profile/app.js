async function lockedProfile() {
    //console.log('TODO...');
    let baseUrl = 'http://localhost:3030/jsonstore/advanced/profiles';
    let main = document.getElementById('main');
    main.innerHTML = '';

    const response = await fetch(baseUrl);
    const data = await response.json();

    let idNumber = 0;

    for (const user of Object.values(data)) {
        idNumber++;
        let userCard = document.createElement('div');
        userCard.className = 'profile';

        userCard.innerHTML = `<img src="./iconProfile2.png" class="userIcon" />
                              <label>Lock</label>
                              <input type="radio" name="user${idNumber}Locked" value="lock" checked>
                              <label>Unlock</label>
                              <input type="radio" name="user${idNumber}Locked" value="unlock"><br>
                              <hr>
                              <label>Username</label>
                              <input type="text" name="user${idNumber}Username" value="${user.username}" disabled readonly />
                              <div id="user1HiddenFields" style="display:none">
                                  <hr>
                                  <label>Email:</label>
                                  <input type="email" name="user${idNumber}Email" value="${user.email}" disabled readonly />
                                  <label>Age:</label>
                                  <input type="email" name="user${idNumber}Age" value="${user.age}" disabled readonly />
                              </div>
                              <button>Show more</button>`;

        main.appendChild(userCard);
    }

    let buttonElements = document.querySelectorAll('button');

    for (let i = 0; i < buttonElements.length; i++) {
        let currentButton = buttonElements[i];
        let profile = currentButton.parentElement;
        let lockedProfiles = profile.querySelector('input[value="lock"]');
        let hiddenInfo = profile.querySelector(`#user1HiddenFields`);

        currentButton.addEventListener('click', () => {
            if (!lockedProfiles.checked && currentButton.textContent == 'Show more') {
                hiddenInfo.style.display = 'block';
                currentButton.textContent = 'Hide it';
            }
            else if (!lockedProfiles.checked && currentButton.textContent == 'Hide it') {
                hiddenInfo.style.display = 'none';
                currentButton.textContent = 'Show more';
            }
        })
    }
}