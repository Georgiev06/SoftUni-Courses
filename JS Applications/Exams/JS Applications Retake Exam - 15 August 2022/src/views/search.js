import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { searchShoe } from "../api/data.js";

let isCLicked = false;

const searchTemplate = (shoes, user, onSubmit) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form class="search-wrapper cf" @submit=${onSubmit}>
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
        <button type="submit">Search</button>
    </form>

    <h3>Results:</h3>

    <div id="search-container">
        <ul class="card-wrapper">
            ${isCLicked ?
                shoes.length === 0 
                ? html`<h2>There are no items added yet</h2>` 
                : shoes.map(shoe => shoeTemplate(shoe, user))
             :nothing
            }
        </ul>
    </div>
</section>
`;

const shoeTemplate = (shoe, user) => html`<li class="card">
    <img src="${shoe.imageUrl}" alt="travis" />
    <p>
        <strong>Brand: </strong><span class="brand">${shoe.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${shoe.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${shoe.value}</span>$</p>
    ${user ? html`<a class="details-btn" href="/details/${shoe._id}">Details</a>` : html``}
</li>`;

export async function searchPage(ctx) {
    const user = sessionStorage.getItem('userId');
    const brand = ctx.querystring.split('=')[1];
    const shoes = brand == undefined ? [] : await searchShoe(brand);
    
    ctx.render(searchTemplate(shoes, user, onSubmit))
    function onSubmit(e) {
        e.preventDefault();
        
        isCLicked = true;
        const formData = new FormData(e.target);
        const query = formData.get('search').trim();
        ctx.page.redirect(`/search?query=${query}`);
    }
    
    isCLicked = false;
}