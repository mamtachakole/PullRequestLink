// GoalManager.tsx

export function GoalManager(props: Props) {
  // ...

  const [icon, setIcon] = useState<string | null>(null)

  useEffect(() => {
    setIcon(props.goal.icon)
  }, [props.goal.id, props.goal.icon])

  const hasIcon = () => icon != null

  const addIconOnClick = (event: React.MouseEvent) => {
    event.stopPropagation()
    setEmojiPickerIsOpen(true)
  }

  return (
    {/* ... */}
    <AddIconButtonContainer hasIcon={hasIcon()}>
      <TransparentButton onClick={addIconOnClick}>
        <FontAwesomeIcon icon={faSmile} size="2x" />
        <AddIconButtonText>Add icon</AddIconButtonText>
      </TransparentButton>
    </AddIconButtonContainer>
    {/* ... */}
  )
}
This is the model answe
