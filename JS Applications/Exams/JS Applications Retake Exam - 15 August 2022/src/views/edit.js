import { html } from "../../node_modules/lit-html/lit-html.js";
import { editShoe, getShoesById } from "../api/data.js";

const editTemplate = (shoe, onSubmit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit item</h2>
        <form class="edit-form" @submit=${onSubmit}>
            <input type="text" name="brand" id="shoe-brand" placeholder="Brand" value=${shoe.brand} />
            <input type="text" name="model" id="shoe-model" placeholder="Model" value=${shoe.model} />
            <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" value=${shoe.imageUrl} />
            <input type="text" name="release" id="shoe-release" placeholder="Release date" value=${shoe.release} />
            <input type="text" name="designer" id="shoe-designer" placeholder="Designer" value=${shoe.designer} />
            <input type="text" name="value" id="shoe-value" placeholder="Value" value=${shoe.value} />

            <button type="submit">post</button>
        </form>
    </div>
</section>
`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const shoe = await getShoesById(id)

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);

        const shoe = {
            brand: formData.get('brand').trim(),
            model: formData.get('model').trim(),
            imageUrl: formData.get('imageUrl').trim(),
            release: formData.get('release').trim(),
            designer: formData.get('designer').trim(),
            value: formData.get('value').trim(),
        }

        if (shoe.brand == '' || shoe.model == '' || shoe.imageUrl == '' || shoe.release == '' || shoe.designer == '' || shoe.value == '') {
            return alert('Invalid data!');
        }

        await editShoe(id, shoe);
        ctx.page.redirect('/details/' + id);
    }

    ctx.render(editTemplate(shoe, onSubmit));
}