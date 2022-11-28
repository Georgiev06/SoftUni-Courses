import { html } from "../../node_modules/lit-html/lit-html.js"
import { getShoes } from "../api/data.js";

const shoesTemplate = (shoe, user) => html`
        <li class="card">
            <img src="${shoe.imageUrl}" alt="eminem" />
            <p>
                <strong>Brand: </strong><span class="brand">${shoe.brand}</span>
            </p>
            <p>
                <strong>Model: </strong><span class="model">${shoe.model}</span>
            </p>
            <p><strong>Value:</strong><span class="value">${shoe.value}</span>$</p>
            <a class="details-btn" href="/details/${shoe._id}">Details</a>
        </li>
`;

const dashboardTemplate = (shoes, user) => html`
<section id="dashboard">
    <h2>Collectibles</h2>
    <ul class="card-wrapper">
        ${shoes.length != 0 ? shoes.map(shoe => shoesTemplate(shoe, user)) : html`<h2>There are no items added yet.</h2>
        `}
    </ul>
</section>
`;


export async function dashboardPage(ctx) {
    const user = sessionStorage.getItem('userId');
    const shoes = await getShoes();
    ctx.render(dashboardTemplate(shoes, user));
}