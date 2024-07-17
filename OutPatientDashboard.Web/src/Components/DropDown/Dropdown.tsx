import { useState } from "react";

interface ListItem {
  id: string;
  name: string;
}

interface Props {
  items: ListItem[];
  heading: string;
  onSelectItem: (item: string) => void;
}

function Dropdown({ items, heading, onSelectItem }: Props) {
  const [selectedIndex, setSelectedIndex] = useState(-1);

  return (
    <div className="dropdown">
      <span>{heading}</span>
      <button
        className="btn btn-secondary dropdown-toggle"
        type="button"
        data-bs-toggle="dropdown"
        aria-expanded="false"
      >
        {selectedIndex === -1 ? "Select" : items[selectedIndex].name}
      </button>
      <ul className="dropdown-menu">
        {items &&
          items.map((item, index) => (
            <li
              key={item.id}
              onClick={() => {
                setSelectedIndex(index);
                onSelectItem(item.id);
              }}
              className={
                selectedIndex == index
                  ? "dropdown-item active"
                  : "dropdown-item"
              }
            >
              {item.name}
            </li>
          ))}
      </ul>
    </div>
  );
}

export default Dropdown;
