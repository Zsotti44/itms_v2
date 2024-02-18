/* eslint-disable react/jsx-key */
import { useState, useEffect } from "react";
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
  GridToolbarQuickFilter,
} from "@mui/x-data-grid";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Close";
import { newTruck, editTruck,getTrucks } from "../../controllers/truckControllers";
import Grid from "@mui/material/Unstable_Grid2"; // Grid version 2

function EditToolbar(props) {
  // eslint-disable-next-line react/prop-types
  const { setTrucks, setRowModesModel, Trucks } = props;
  const handleClick = () => {
    // eslint-disable-next-line react/prop-types
    const id = Trucks.length + 1;
    setTrucks((oldRows) => [
      ...oldRows,
      {
        id,
        Plate: "",
        standalone: false,
        adr: false,
        traffic: false,
        owner: "",
        active: true,
        isNew: true,
      },
    ]);
    setRowModesModel((oldModel) => ({
      ...oldModel,
      [id]: { mode: GridRowModes.Edit, fieldToFocus: "plate" },
    }));
  };
  return (
    <Grid container spacing={2}>
      <Grid xs={8} md={8}>
        <GridToolbarContainer>
          <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
            Új vontató
          </Button>
        </GridToolbarContainer>
      </Grid>
      <Grid xs={4} md={4}>
        <GridToolbarQuickFilter />
      </Grid>
    </Grid>
  );
}

const Trucks = () => {
  const [Trucks, setTrucks] = useState([]);
  const [Error, setError] = useState(false);
  const [rowModesModel, setRowModesModel] = useState({});

  useEffect(() => {
    getTrucks()
      .then((data) => {
        console.log(data.data)
        if (data.success) setTrucks(data.data);
        else setError(true);
      })
      .catch((error) => {
        console.error(error);
        setError(true);
      });
  }, []);

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const handleEditClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
  };

  const handleSaveClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
  };
  const handleCancelClick = (id) => () => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });

    const editedRow = Trucks.find((row) => row.id === id);
    if (editedRow.isNew) {
      setTrucks(Trucks.filter((row) => row.id !== id));
    }
  };

  const processRowUpdate = (newRow) => {
    if (newRow.isNew) {
      newTruck(newRow).then((data) => {
        setTrucks(data.data);
        console.log(data.data)

      });
    } else {
      editTruck(newRow).then((data) => {
        setTrucks(data.data);
        console.log(data.data)
      });
    }
    const updatedRow = { ...newRow, isNew: false };
    return updatedRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };

  const onProcessRowUpdateError = (e) => {
    console.log(e);
  };
  const columns = [
    { field: "id", headerName: "ID", width: 150, editable: false },
    { field: "plate", headerName: "Rendszám", width: 150, editable: true },
    {
      field: "standalone",
      headerName: "Standalone",
      width: 150,
      editable: true,
      type: "boolean",
    },
    {
      field: "adr",
      headerName: "ADR",
      width: 150,
      editable: true,
      type: "boolean",
    },
    {
      field: "traffic",
      headerName: "Közút",
      width: 150,
      editable: true,
      type: "boolean",
    },
    { field: "owner", headerName: "Tulajdonos", width: 150, editable: true },
    {
      field: "active",
      headerName: "Aktív",
      width: 150,
      editable: true,
      type: "boolean",
    },
    {
      field: "actions",
      type: "actions",
      headerName: "Műveletek",
      width: 100,
      cellClassName: "actions",
      getActions: ({ id }) => {
        const isInEditMode = rowModesModel[id]?.mode === GridRowModes.Edit;
        if (isInEditMode) {
          return [
            <GridActionsCellItem
              icon={<SaveIcon />}
              label="Save"
              sx={{
                color: "primary.main",
              }}
              onClick={handleSaveClick(id)}
            />,
            <GridActionsCellItem
              icon={<CancelIcon />}
              label="Cancel"
              className="textPrimary"
              onClick={handleCancelClick(id)}
              color="inherit"
            />,
          ];
        }

        return [
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            className="textPrimary"
            onClick={handleEditClick(id)}
            color="inherit"
          />,
        ];
      },
    },
  ];
  return (
    <>
      {Error ? (
        <h1>Hiba!</h1>
      ) : (
        <>
          <Box
            sx={{
              height: 700,
              width: "100%",
              "& .actions": {
                color: "text.secondary",
              },
              "& .textPrimary": {
                color: "text.primary",
              },
            }}
          >
            <DataGrid
              rows={Trucks}
              columns={columns}
              editMode="row"
              rowModesModel={rowModesModel}
              onRowModesModelChange={handleRowModesModelChange}
              onRowEditStop={handleRowEditStop}
              processRowUpdate={processRowUpdate}
              onProcessRowUpdateError={onProcessRowUpdateError}
              slots={{
                toolbar: EditToolbar,
              }}
              slotProps={{
                toolbar: {
                  setTrucks,
                  setRowModesModel,
                  Trucks,
                  showQuickFilter: true,
                },
              }}
            />
          </Box>
        </>
      )}
    </>
  );
};
export default Trucks;
