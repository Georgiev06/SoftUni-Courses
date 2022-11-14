const section = document.getElementById('details-view');
const main = document.getElementsByTagName('main')[0];
const form = section.querySelector('form');
const themeContentWrapper = document.getElementById("theme-content-wrapper");
let id = '';

form.addEventListener("submit", onSubmit)
section.remove();

export async function showDetails(e) {
    if (!e) {
        return
    }

    if (e.target.tagName === 'H2') {
        id = e.target.parentElement.id
    }
    else if (e.target.tagName === 'A') {
        id = e.target.id
    }

    appendElement();
}

async function appendElement() {
    const topic = await loadTopic(id)
    const comments = await loadComment(id)

    const res = topicTemplate(topic, comments);
    themeContentWrapper.replaceChildren(res);
    main.replaceChildren(section)
}

function topicTemplate(topic, comments) {
    const topicContainer = document.createElement("div");
    topicContainer.classList.add("theme-title");
    topicContainer.innerHTML = `
                        <div class="theme-name-wrapper">
                            <div class="theme-name">
                                <h2>${topic.topicName}</h2>
                            </div>
                        </div>
    `;
    const commentContainer = document.createElement("div");
    commentContainer.classList.add("comment");

    commentContainer.innerHTML = `
    <div class="header">
        <img src="./static/profile.png" alt="avatar">
        <p><span>${topic.username}</span> posted on <time>${topic.date}</time></p>

    <p class="post-content">${topic.postText}</p>
    </div>
   `
    comments.forEach(comment => {
        const currComment = createComment(comment);
        commentContainer.appendChild(currComment);
    })

    return commentContainer;
}

function createComment(data) {
    const container = document.createElement("div")
    container.classList.add("user-comment")
    container.innerHTML = `
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <p><strong>${data.username}</strong> commented on <time>${data.date}</time></p>
                <div class="post-content">
                 <p>${data.postText}</p>
              </div>
            </div>
        </div>`;
    return container;
}

function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const { postText, username } = Object.fromEntries(formData);
    cretePost({ postText, username, id, date: new Date() });
    clearForm()
}

async function cretePost(body) {
    const url = "http://localhost:3030/jsonstore/collections/myboard/comments";
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(body)
        })

        const data = await response.json();
        appendElement();
        clearForm()

        if (!response.ok) {
            throw new Error(data.message);
        }

    } catch (error) {
        console.log(error.message);
    }
}

async function loadComment(id) {
    const url = `http://localhost:3030/jsonstore/collections/myboard/comments`;
    try {
        let response = await fetch(url);
        let data = await response.json();

        if (!response.ok) {
            throw new Error(data.message);
        }

        const filteredData = Object.values(data).filter(x => x.id === id)
        return filteredData;

    } catch (error) {
        console.log(error.message);
    }
}

async function loadTopic(id) {
    const url = `http://localhost:3030/jsonstore/collections/myboard/posts/${id}`;

    try {
        let response = await fetch(url);
        let data = await response.json();

        if (!response.ok) {
            throw new Error(data.message);
        }
        return data;

    } catch (error) {
        console.log(error.message);
    }

}

function clearForm() {
    form.reset();
}