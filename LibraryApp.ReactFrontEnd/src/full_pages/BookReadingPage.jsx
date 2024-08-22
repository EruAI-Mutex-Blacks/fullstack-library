import { Link } from "react-router-dom";


function BookReadingPage() {
    return (
        <div className="container my-5 p-2 bg-light rounded d-flex text-center">
            <div className="col-9 pe-2">
                <div className="d-flex justify-content-center bg-success-subtle border-bottom border-dark px-3 pt-3 rounded mb-2">
                    <h5>Selected page number</h5>
                </div>
                <div className="p-3 bg-success-subtle rounded">
                    <p>SELECTED PAGE CONTENT <br />Lorem ipsum dolor, sit amet consectetur adipisicing elit. Modi corporis excepturi reiciendis molestiae neque voluptatibus veritatis ex quaerat, perspiciatis voluptate qui autem unde error et aspernatur esse dolore quis sunt.
                    Ratione qui, ullam recusandae repellendus autem facere similique! Rerum asperiores atque laborum delectus. Similique, facilis? Quis ut molestiae sapiente, in atque autem reiciendis eius adipisci soluta iusto voluptas. Temporibus, sit.
                    Pariatur odio tempore ducimus voluptas, laborum quia in ipsam rerum culpa et nesciunt magnam incidunt, voluptatibus debitis ipsa? Ratione dicta vero omnis ipsam odio reprehenderit pariatur perferendis! Ratione, iusto culpa!
                    Pariatur cumque maiores veniam possimus fugit dolore earum assumenda, inventore in similique molestiae perferendis vitae facilis accusantium debitis voluptate voluptatibus sint aliquid quidem voluptates vero quis ex? Officia, quia aliquam.
                    Voluptatem, inventore iure aliquid soluta ex ipsa expedita enim? Magni hic, unde cumque quibusdam nemo maxime facilis corporis tenetur cupiditate eaque eligendi, animi qui? Dolore voluptatibus veniam dicta sed omnis!
                    Quisquam non et eius debitis voluptatum? Modi, beatae cupiditate. Veniam est voluptates eveniet nemo consectetur aut, tenetur, fuga repudiandae quos quibusdam voluptatibus iste placeat commodi delectus facilis facere labore unde!
                    Animi qui odit id amet expedita dignissimos hic ipsum eum earum itaque, praesentium nihil dolorum voluptatibus saepe! Quo dolor error est optio praesentium nostrum quae sint, sequi quod ad rem?
                    Sit laudantium maiores consequuntur commodi, nihil voluptatem veritatis, asperiores quis, cupiditate molestiae delectus voluptates beatae. Ea natus minus sed vel, ullam iste optio fugit alias! Fugit, expedita rerum. Neque, porro!
                    Rerum, voluptatibus doloremque non placeat quas delectus molestiae alias accusamus, labore nesciunt dolores aliquam veniam dolor velit provident a nostrum, nobis officia aut quae quod voluptas dignissimos laboriosam. Ea, tempore.
                    Sequi praesentium autem eaque maiores, explicabo recusandae non sapiente, ad provident dolore nostrum illo nisi, repudiandae animi neque numquam maxime earum culpa ex amet aut in ullam. Possimus, ipsam repellendus.</p>
                </div>
            </div>
            <div className="col-3 ps-2">
                <div className="d-flex justify-content-center bg-success-subtle border-bottom border-dark px-3 pt-3 pb-0 rounded mb-2">
                <h4>Pages</h4>
                </div>
                <div className="d-flex justify-content-center flex-wrap p-3 bg-success-subtle rounded">
                    <Link className="btn btn-success me-2 mb-2">1</Link>
                    <Link className="btn btn-success me-2 mb-2">2</Link>
                    <Link className="btn btn-success me-2 mb-2">3</Link>
                    <Link className="btn btn-success me-2 mb-2">4</Link>
                    <Link className="btn btn-success me-2 mb-2">5</Link>
                    <Link className="btn btn-success me-2 mb-2">6</Link>
                    <Link className="btn btn-success me-2 mb-2">7</Link>
                    <Link className="btn btn-success me-2 mb-2">8</Link>
                    <Link className="btn btn-success me-2 mb-2">9</Link>
                    <Link className="btn btn-success me-2 mb-2">10</Link>
                    <Link className="btn btn-success me-2 mb-2">11</Link>
                    <Link className="btn btn-success me-2 mb-2">12</Link>
                    <Link className="btn btn-success me-2 mb-2">13</Link>
                    <Link className="btn btn-success me-2 mb-2">14</Link>
                    <Link className="btn btn-success me-2 mb-2">15</Link>
                    <Link className="btn btn-success me-2 mb-2">16</Link>
                    <Link className="btn btn-success me-2 mb-2">17</Link>
                    <Link className="btn btn-success me-2 mb-2">18</Link>
                </div>
            </div>
        </div>
    );
}

export default BookReadingPage;