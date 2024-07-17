import { useEffect, useState } from "react";
import Dropdown from "../../Components/DropDown/Dropdown";
import { getData } from "../../api";
import "./PhysicianThroughput.css";

interface ListItem {
  id: string;
  name: string;
}

function PhysicianThroughput() {
  const [listItems, setListItems] = useState<ListItem[]>();
  const [throughtputCount, setThroughtputCount] = useState(0);

  useEffect(() => {
    getData(import.meta.env.VITE_BASE_URL + "physician")
      .then((response) => response)
      .then((response) => setListItems(response));
  }, []);

  const handleSelectItem = (item: string) => {
    getData(import.meta.env.VITE_BASE_URL + "physician/throughput/" + item)
      .then((response) => response)
      .then((response) => setThroughtputCount(response));

    console.log(item);
  };

  return (
    <div className="throughputcard">
      <div className="row">
        <h4>Physician throughput</h4>
      </div>

      <div className="row">
        <div className="col">
          <Dropdown
            items={listItems as ListItem[]}
            heading="Providers"
            onSelectItem={handleSelectItem}
          ></Dropdown>
        </div>

        <div className="col">
          <h1 className="count">{throughtputCount}</h1>
        </div>

        <div className="col">
          <img src="/Provider.png" className="float-right" alt="..."></img>
        </div>
      </div>
    </div>
  );
}

export default PhysicianThroughput;
