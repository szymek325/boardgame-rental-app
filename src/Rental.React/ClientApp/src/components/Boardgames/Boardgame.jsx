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

    updateRow = async (boardgame) => {
        boardgame.name = this.state.name;
        boardgame.price = this.state.price;
        boardgame.boardGameGuid = boardgame.id;
        await fetch('api/v1/BoardGame', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'PUT',
            body: JSON.stringify(boardgame)
        })
            .then(async response => {
                if (!response.ok) {
                    await response.json().then(data => {
                        throw new Error(data.Message)
                    });
                }
                else {
                    this.setState({ inEditMode: false, boardgame: boardgame })
                }
            })
            .catch(error => {
                alert(error.message)
            });
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
                    onButtonClick={this.editRow}
                    onRemoveClick={this.props.deleteMethod}>
                </BoardgameDisplay>

        return (component)
    }
}

export default Boardgame;