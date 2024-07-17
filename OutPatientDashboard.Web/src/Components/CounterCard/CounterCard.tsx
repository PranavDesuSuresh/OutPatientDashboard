import "./CounterCard.css";
import "font-awesome/css/font-awesome.min.css";

interface Props {
  heading: string;
  iconName: string;
  count: number;
}

const CountCard = (props: Props) => {
  return (
    <div className="countercard col">
      <h4>{props.heading}</h4>
      <div className="row">
        <h1 className="col count">{props.count}</h1>
        <div className="col image">
          <img src={"/" + props.iconName} alt="..."></img>
        </div>
      </div>
    </div>
  );
};

export default CountCard;
