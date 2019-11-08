import React, { Component } from 'react'

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
            <table className='table table-striped center' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>CreationTime</th>
                    </tr>
                </thead>
                <tbody>
                    {boardgames.map((boardgame,i) =>
                        <tr key={boardgame.id}>
                            <td>{i+1}</td>
                            <td>{boardgame.name}</td>
                            <td>{boardgame.price}</td>
                            <td>{boardgame.creationTime}</td>
                        </tr>
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
                <p/>
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
