import React from 'react'

const BoardgameDisplay = (props) => {
    return (
        <tr>
            <td>{props.i + 1}</td>
            <td>{props.boardgame.name}</td>
            <td>{props.boardgame.price}</td>
            <td>{props.boardgame.creationTime}</td>
            <td><button onClick={props.onButtonClick} className="btn btn-primary">Edit</button></td>
        </tr>
    )
}

export default BoardgameDisplay
