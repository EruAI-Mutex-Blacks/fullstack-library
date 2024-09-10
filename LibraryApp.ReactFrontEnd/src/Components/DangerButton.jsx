
function DangerButton({ text, callback }) {
    return (<button onClick={callback} className = "border border-transparent inline-block rounded px-4 py-2 bg-danger hover:bg-danger-dark hover:ring-2 hover:ring-danger transition-all duration-100 text-text active:bg-danger-dark/60" > { text }</button >);
}

export default DangerButton;