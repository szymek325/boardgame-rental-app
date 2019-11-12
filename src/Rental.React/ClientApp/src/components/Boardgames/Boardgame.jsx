import React, { Component } from 'react'
import BoardgameDisplay from './BoardgameDisplay';
import BoardgameInEdit from './BoardgameInEdit';

export class Boardgame extends Component {
    constructor(props) {
        super(props);
        this.state = {
            inEditMode: false,
            boardgame: props.boardgame,
            name: props.boardgame.name,
            price: props.boardgame.price
        };
    }

    onChangeName = (event) => {
        this.setState({ name: event.target.value })
    }

    onChangePrice = (event) => {
        let price = parseInt(event.target.value)
        this.setState({ price: price })
    }

    editRow = () => {
        this.setState({ inEditMode: true });
    }

    cancelRow = () => {
        this.setState({ inEditMode: false });
    }

    updateRow = (boardgame) => {
        boardgame.name = this.state.name;
        boardgame.price = this.state.price;
        boardgame.boardGameGuid = boardgame.id;
        fetch('api/v1/BoardGame', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'PUT',
            body: JSON.stringify(boardgame)
        })
            .then(response => this.setState({ inEditMode: false, boardgame: boardgame }))
            .catch(error => alert(error));
    }

    render() {
        let component = "";
        if (this.state.inEditMode)
            component =
                <BoardgameInEdit
                    boardgame={this.state.boardgame}
                    i={this.props.i}
                    onButtonSave={this.updateRow}
                    onButtonCancel={this.cancelRow}
                    onChangeName={this.onChangeName}
                    onChangePrice={this.onChangePrice}>
                </BoardgameInEdit>
        else
            component =
                <BoardgameDisplay
                    boardgame={this.state.boardgame}
                    i={this.props.i}
                    onButtonClick={this.editRow}>
                </BoardgameDisplay>

        return (component)
    }
}

export default Boardgame;