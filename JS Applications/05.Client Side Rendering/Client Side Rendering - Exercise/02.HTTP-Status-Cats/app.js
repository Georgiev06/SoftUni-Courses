import {html, render} from '../node_modules/lit-html/lit-html.js';
import {cats} from './catSeeder.js'

const root = document.getElementById('allCats');
root.addEventListener('click', toggleDetails)

const catCardTemplate = (cat) => html `
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn">Show status code</button>
                <div class="status" style="display: none" id="${cat.id}">
                    <h4>Status Code: ${cat.statusCode}</h4>
                    <p>${cat.statusMessage}</p>
                </div>
        </div>
</li>`;

showCats();
 
function showCats() {
    render(html`<ul>${cats.map(cat => catCardTemplate(cat))}</ul>`, root);
};

function toggleDetails(e) {
    if (e.target.classList.contains('showBtn')) {

        const button = e.target;
        const parent = e.target.parentElement;
        const status = parent.querySelector('.status');

        if (button.textContent === 'Show status code') {
            button.textContent = 'Hide status code'
            status.style.display = "block";
        }
        else {
            button.textContent = 'Show status code'
            status.style.display = "none";
        }
    }
}
