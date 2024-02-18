import { Route, Routes } from "react-router-dom";
import Home from "./Pages/Home";
import NoPage from "./Pages/NoPage";
import Trucks from "./Pages/trucks/Trucks";
import TruckDrivers from "./Pages/truckdrivers/TruckDrivers";
import Trailers from "./Pages/trailers/trailers";
import Shifts from "./Pages/shifts/shifts";
import WorkTickets from "./Pages/WorkTickets/worktickets";

const Itms_router = () => {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/trucks" element={<Trucks />}/> 
        <Route path="/truckDrivers" element={<TruckDrivers />}/> 
        <Route path="/trailers" element={<Trailers />}/> 
        <Route path="/shifts" element={<Shifts />}/> 
        <Route path="/worktickets" element={<WorkTickets />}/> 

        <Route path="*" element={<NoPage />} />
      </Routes>
    </>
  );
};

export default Itms_router;
