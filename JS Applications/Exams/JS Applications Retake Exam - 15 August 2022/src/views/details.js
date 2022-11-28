import { html, nothing } from "../../node_modules/lit-html/lit-html.js"
import { getShoesById } from "../api/data.js";


const detailsTemplate = (shoe, hasOwner) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Shoe Details</p>
        <div id="img-wrapper">
            <img src="${shoe.imageUrl}" alt="example1" />
        </div>
        <div id="info-wrapper">
            <p>Brand: <span id="details-brand">${shoe.brand}</span></p>
            <p>
                Model: <span id="details-model">${shoe.model}</span>
            </p>
            <p>Release date: <span id="details-release">${shoe.release}</span></p>
            <p>Designer: <span id="details-designer">${shoe.designer}</span></p>
            <p>Value: <span id="details-value">${shoe.value}</span></p>
        </div>

        ${hasOwner ? html`<div id="action-buttons">
            <a href="/edit/${shoe._id}" id="edit-btn">Edit</a>
            <a href="/delete/${shoe._id}" id="delete-btn">Delete</a>
        </div>` : nothing}
        <!--Edit and Delete are only for creator-->
    </div>
</section>
`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const shoe = await getShoesById(id);
    const userId = sessionStorage.getItem('userId');
    let hasOwner = false;
    if (userId == shoe._ownerId) {
        hasOwner = true;
    }

    ctx.render(detailsTemplate(shoe, hasOwner));
}