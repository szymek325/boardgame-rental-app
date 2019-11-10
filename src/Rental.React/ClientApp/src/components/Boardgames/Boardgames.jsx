import React, { Component } from 'react'
import Boardgame from './Boardgame'

export class Boardgames extends Component {
    static displayName = Boardgames.name;

    constructor(props) {
        super(props);
        this.state = { boardgames: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(boardgames) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>CreationTime</th>
                    </tr>
                </thead>
                <tbody>
                    {boardgames.map((boardgame, i) =>
                        <Boardgame key={boardgame.id} boardgame={boardgame} i={i}></Boardgame>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Boardgames.renderForecastsTable(this.state.boardgames);

        return (
            <div>
                <h1 id="tabelLabel" >Boardgames</h1>
                <p />
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('api/v1/BoardGame');
        console.log(response);
        const data = await response.json();
        console.log(data);
        this.setState({ boardgames: data, loading: false });
    }
}
