import {showDetails} from './details.js'

const section = document.getElementById('home-view');
const main = document.getElementsByTagName('main')[0];
const form = document.querySelector('#home-view form');

form.addEventListener("submit", onSubmit);

section.remove();

const url = "http://localhost:3030/jsonstore/collections/myboard/posts";

export async function showHome() {
    const topicContainer = section.querySelector('.topic-title')
    const posts = await loadPost();
    const content = Object.values(posts).map(x => topicTemplate(x))
    topicContainer.replaceChildren(...content);
    main.replaceChildren(section);
}

function topicTemplate(data) {
    const container = document.createElement("div");
    container.classList.add("topic-container");
    container.innerHTML = `
    <div class="topic-name-wrapper" >
        <div class="topic-name">
        <a href="#" class="normal" id="${data._id}">
            <h2>${data.topicName}</h2>
        </a>
        <div class="columns">
            <div>
                <p>Date: <time>${data.date}</time></p>
                <div class="nick-name">
                    <p>Username: <span>${data.username}</span></p>
                </div>
            </div>
        </div>
        </div>
    </div>`;
   
    container.querySelector("a").addEventListener("click", showDetails)
    return container;
}

function onSubmit(e) { 
    e.preventDefault();
    if (e.submitter.innerHTML === "Cancel") {
        return clearForm();
    }

    const formData = new FormData(form); 
    const { topicName, username, postText } = Object.fromEntries(formData);

    createPost({ topicName, username, postText, date : new Date() });
    clearForm();
}

async function createPost(body) {
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(body)
        })
    
        const data = await response.json();
    
        if (!response.ok) {
            throw new Error(data.message);
        }
        
    } catch (error) {
        console.log(error.message);
    }
} 

async function loadPost() {
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

showDetails();