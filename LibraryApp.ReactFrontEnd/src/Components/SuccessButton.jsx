
function SuccessButton({ text, callback }) {
    return (<button onClick={callback} className = "border border-transparent inline-block rounded px-4 py-2 bg-success hover:bg-success-dark hover:ring-2 hover:ring-success transition-all duration-100 text-text :bg-success-dark/60" > { text }</button >);
}

export default SuccessButton;