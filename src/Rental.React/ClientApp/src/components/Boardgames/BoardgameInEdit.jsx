import React from 'react'

const BoardgameInEdit = (props) => {
    return (
        < tr >
            <td>{props.i + 1}</td>
            <td><input type="text" defaultValue={props.boardgame.name} onChange={props.onChangeName}></input></td>
            <td><input type="number" defaultValue={props.boardgame.price} onChange={props.onChangePrice}></input></td>
            <td>{props.boardgame.creationTime}</td>
            <td>
                <button onClick={props.onButtonSave} className="btn btn-success">Save</button>
                <button onClick={props.onButtonCancel} className="btn btn-warning">Cancel</button>
            </td>
        </tr >
    )
}

export default BoardgameInEdit




