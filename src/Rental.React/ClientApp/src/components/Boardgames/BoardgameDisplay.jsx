import React from 'react'

const BoardgameDisplay = (props) => {
    return (
        <tr>
            <td>{props.i + 1}</td>
            <td>{props.boardgame.id.substring(0, 8)}</td>
            <td>{props.boardgame.name}</td>
            <td>{props.boardgame.price}</td>
            <td>{props.boardgame.creationTime}</td>
            <td>
                <button onClick={props.onButtonClick} className="btn btn-primary">Edit</button>
                <button onClick={() => props.onRemoveClick(props.boardgame.id)} className="btn btn-danger">Remove</button>
            </td>
        </tr>
    )
}

export default BoardgameDisplay
