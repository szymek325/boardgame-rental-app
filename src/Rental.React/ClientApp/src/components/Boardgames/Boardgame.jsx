import React, { Component } from 'react'
import BoardgameDisplay from './BoardgameDisplay';
import BoardgameInEdit from './BoardgameInEdit';

export class Boardgame extends Component {
    constructor(props) {
        super(props);
        this.state = {
            inEditMode: false,
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
        console.log('dsadsadsa')
        this.setState({ inEditMode: true });
    }

    cancelRow = () => {
        this.setState({ inEditMode: false });
    }

    updateRow = () => {
        if (this.inEditMode)
            console.log('updated')
        this.setState({ inEditMode: false });
        this.props.boardgame.name = this.state.name;
        this.props.boardgame.price = this.state.price;
    }

    render() {
        let component = "";
        if (this.state.inEditMode)
            component =
                <BoardgameInEdit
                    boardgame={this.props.boardgame}
                    i={this.props.i}
                    onButtonSave={this.updateRow}
                    onButtonCancel={this.cancelRow}
                    onChangeName={this.onChangeName}
                    onChangePrice={this.onChangePrice}>
                </BoardgameInEdit>
        else
            component =
                <BoardgameDisplay
                    boardgame={this.props.boardgame}
                    i={this.props.i}
                    onButtonClick={this.editRow}>
                </BoardgameDisplay>

        return (component)
    }
}

export default Boardgame;