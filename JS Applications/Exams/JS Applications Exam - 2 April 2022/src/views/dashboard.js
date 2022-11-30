import { html } from "../../node_modules/lit-html/lit-html.js"
import { getAllAnimals } from "../api/data.js";

const dashboardTemplate = (animals) => html`<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">
        ${animals.length === 0 ? html`<p class="no-pets">No pets in dashboard</p>` : animals.map(animal =>
    animalBoardTemplate(animal))}
    </div>
</section>`;

const animalBoardTemplate = (animal) => html`<div class="animals-board">
    <img class="animal-image-cover" src="${animal.image}">
    <h2 class="name">${animal.name}</h2>
    <h3 class="breed">${animal.breed}</h3>
    <div class="action">
        <a class="btn" href="/details/${animal._id}">Details</a>
    </div>
</div>`;

export async function dashboardPage(ctx) {
    const animals = await getAllAnimals();
    ctx.render(dashboardTemplate(animals));
}