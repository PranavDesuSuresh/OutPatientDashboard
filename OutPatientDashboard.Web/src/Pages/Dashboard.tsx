import { useState, useEffect } from "react";
import CounterCard from "../Components/CounterCard/CounterCard";
import "./Dashboard.css";
import { getData } from "../api";
import PhysicianThroughput from "../CustomComponents/PhysicianThroughPut/PhysicianThroughput";

function Dashboard() {
  const [selectedInPatientCount, setSelectedInPatientCount] = useState(-1);
  const [selectedPatientCount, setSelectedPatientCount] = useState(-1);

  useEffect(() => {
    getData(import.meta.env.VITE_BASE_URL + "patient/incarecount").then(
      (response) => setSelectedInPatientCount(response)
    );

    getData(import.meta.env.VITE_BASE_URL + "patient/dischargedbydate")
      .then((response) => response)
      .then((response) => setSelectedPatientCount(response));
  }, []);

  return (
    <div className="dashboardbody container px-1">
      <h1 className="banner row">OutPatient Dashboard</h1>

      <div className="row">
        <CounterCard
          heading="Patients In Care"
          iconName="bed.svg"
          count={selectedInPatientCount}
        ></CounterCard>

        <CounterCard
          heading="Patients Attended today"
          iconName="patient.png"
          count={selectedPatientCount}
        ></CounterCard>
      </div>

      <div className="row">
        <PhysicianThroughput></PhysicianThroughput>
      </div>
    </div>
  );
}

export default Dashboard;
