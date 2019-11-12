import React, { Component } from 'react'
import Boardgame from './Boardgame'

export class Boardgames extends Component {
    static displayName = Boardgames.name;

    constructor(props) {
        super(props);
        this.state = { boardgames: [], loading: true };
    }

    componentDidMount() {
        this.populateBoardgamesData();
    }

    deleteBoardgame = async (guid) => {
        await fetch('api/v1/BoardGame?id=' + guid, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'DELETE',
        })
            .then(async response => {
                if (!response.ok) {
                    await response.json().then(data => {
                        throw new Error(data.Message)
                    });
                }
                else {
                    this.setState(prevState => ({
                        boardgames: prevState.boardgames.filter(el => el.id !== guid)
                    }));
                    alert("Boardgame with id " + guid + "was removed");
                }
            })
            .catch(error => {
                alert(error.message)
            });

    }

    populateBoardgamesData = async () => {
        await fetch('api/v1/BoardGame')
            .then(response => response.json())
            .then(data => this.setState({ boardgames: data, loading: false }))
            .catch(error => alert('Exception occured when loading Boardgames data'));
    }

    static renderForecastsTable(boardgames, deleteMethod) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Nr</th>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>CreationTime</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {boardgames.map((boardgame, i) =>
                        <Boardgame key={boardgame.id} boardgame={boardgame} i={i} deleteMethod={deleteMethod}></Boardgame>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Boardgames.renderForecastsTable(this.state.boardgames, this.deleteBoardgame);

        return (
            <div>
                <h1 id="tabelLabel" >Boardgames</h1>
                <p />
                {contents}
            </div>
        );
    }
}
