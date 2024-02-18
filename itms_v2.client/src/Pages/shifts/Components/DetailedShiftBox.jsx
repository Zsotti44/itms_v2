import { useState, useEffect } from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
//import DeleteIcon from "@mui/icons-material/DeleteOutlined";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Close";
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
  GridToolbarQuickFilter,
} from "@mui/x-data-grid";
import {
  getShift,
  getTruckSelectOptions,
  getTrailerSelectOptions,
  getDriverSelectOptions,
  editWorkTruck,
  addWorkTruck,
} from "../../../controllers/shiftController";
import Grid from "@mui/material/Unstable_Grid2"; // Grid version 2

const DetailedShiftBox = (props) => {
  const [rows, setRows] = useState([]);
  const [rowModesModel, setRowModesModel] = useState({});
  const [Error, setError] = useState(false);
  const [TruckSelectOptions, setTruckSelectOptions] = useState([]);
  const [TrailerSelectOptions, setTrailerSelectOptions] = useState([]);
  const [DriverSelectOptions, setDriverSelectOptions] = useState([]);
  const [selectedShift, setSelectedShift] = useState(0);

  useEffect(() => {
    // eslint-disable-next-line react/prop-types
    if (selectedShift[0] != props.id && selectedShift[0] != -1) {
      // eslint-disable-next-line react/prop-types
      setSelectedShift(props.id);
      // eslint-disable-next-line react/prop-types
      getShift(props.id)
        .then((data) => {
          if (data.success) setRows(data.data.trucks);
          else setError(true);
        })
        .catch((error) => {
          console.error(error);
          setError(true);
        });

      getTruckSelectOptions()
        .then((data) => {
          if (data.success) setTruckSelectOptions(data.data);
          else setError(true);
        })
        .catch((error) => {
          console.error(error);
          setError(true);
        });

      getTrailerSelectOptions()
        .then((data) => {
          if (data.success) setTrailerSelectOptions(data.data);
          else setError(true);
        })
        .catch((error) => {
          console.error(error);
          setError(true);
        });

      getDriverSelectOptions()
        .then((data) => {
          if (data.success) setDriverSelectOptions(data.data);
          else setError(true);
        })
        .catch((error) => {
          console.error(error);
          setError(true);
        });
    }
    // eslint-disable-next-line react/prop-types
  }, [props.id]);

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

  /*const handleDeleteClick = (id) => () => {
    setRows(rows.filter((row) => row.id !== id));
  };*/

  const handleCancelClick = (id) => () => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });

    const editedRow = rows.find((row) => row.id === id);
    if (editedRow.isNew) {
      setRows(rows.filter((row) => row.id !== id));
    }
  };

  const processRowUpdate = (newRow) => {
    var request = {};
    request.Id = newRow.id;
    request.driver = newRow.driver_name;
    request.trailer = newRow.trailer_plate;
    request.truck = newRow.truck_plate;
    request.shiftid = selectedShift[0];
    if (newRow.isNew) {
      addWorkTruck(request).then((data) => {
        setRows(data.data.trucks);
      });
    } else {
      editWorkTruck(request).then((data) => {
        setRows(data.data.trucks);
      });
    }

    const updatedRow = { ...newRow, isNew: false };
    return updatedRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };

  const columns = [
    { field: "id", headerName: "ID", width: 75, editable: false },
    {
      field: "truck_plate",
      headerName: "Rendszám",
      width: 125,
      editable: true,
      type: "singleSelect",
      valueGetter: (params) => {
        return params.row.truck.id;
      },
      getOptionValue: (value) => value.id,
      getOptionLabel: (value) => value.plate,
      valueOptions: TruckSelectOptions,
    },
    {
      field: "truck_adr",
      headerName: "ADR",
      width: 50,
      editable: false,
      type: "boolean",
      valueGetter: (params) => {
        return params.row.truck.adr;
      },
    },
    {
      field: "trailer_plate",
      headerName: "Rendszám",
      width: 125,
      editable: true,
      type: "singleSelect",
      valueGetter: (params) => {
        return params.row.trailer.id;
      },
      getOptionValue: (value) => value.id,
      getOptionLabel: (value) => value.plate,
      valueOptions: TrailerSelectOptions,
    },
    {
      field: "trailer_adr",
      headerName: "ADR",
      width: 50,
      editable: false,
      type: "boolean",
      valueGetter: (params) => {
        return params.row.trailer.adr;
      },
    },
    {
      field: "driver_name",
      headerName: "Név",
      width: 125,
      editable: true,
      type: "singleSelect",
      valueGetter: (params) => {
        return params.row.driver.id;
      },
      getOptionValue: (value) => value.id,
      getOptionLabel: (value) => value.name,
      valueOptions: DriverSelectOptions,
    },
    {
      field: "driver_adr",
      headerName: "ADR",
      width: 50,
      editable: false,
      type: "boolean",
      valueGetter: (params) => {
        return params.row.driver.adr;
      },
    },
    {
      field: "working",
      headerName: "Foglalt",
      width: 100,
      editable: false,
      type: "boolean",
      valueGetter: (params) => {
        return params.row.working;
      },
    },
    /*{
      field: "price",
      headerName: "Díj",
      width: 100,
      editable: false,
      type: "string",
      valueGetter: (params) => {
        return params.row.price+" €";
      },
    },*/
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
            // eslint-disable-next-line react/jsx-key
            <GridActionsCellItem
              icon={<SaveIcon />}
              label="Save"
              sx={{
                color: "primary.main",
              }}
              onClick={handleSaveClick(id)}
            />,
            // eslint-disable-next-line react/jsx-key
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
          // eslint-disable-next-line react/jsx-key
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            className="textPrimary"
            onClick={handleEditClick(id)}
            color="inherit"
          />,
        ];
        /*
         <GridActionsCellItem
            icon={<DeleteIcon />}
            label="Delete"
            onClick={handleDeleteClick(id)}
            color="inherit"
          />
        */
      },
    },
  ];

  const grouping = [
    {
      groupId: "Vonató",
      children: [{ field: "truck_plate" }, { field: "truck_adr" }],
    },
    {
      groupId: "Pótkocsi",
      children: [{ field: "trailer_plate" }, { field: "trailer_adr" }],
    },
    {
      groupId: "Sofőr",
      children: [{ field: "driver_name" }, { field: "driver_adr" }],
    },
  ];

  return (
    <>
      {Error ? (
        <h1>Hiba!</h1>
      ) : (
        <Box
          sx={{
            height: 500,
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
            experimentalFeatures={{ columnGrouping: true }}
            columnGroupingModel={grouping}
            rows={rows}
            columns={columns}
            editMode="row"
            rowModesModel={rowModesModel}
            onRowModesModelChange={handleRowModesModelChange}
            onRowEditStop={handleRowEditStop}
            processRowUpdate={processRowUpdate}
            slots={{
              toolbar: EditToolbar,
            }}
            slotProps={{
              toolbar: { setRows, setRowModesModel },
            }}
          />
        </Box>
      )}
      ;
    </>
  );
};
function EditToolbar(props) {
  // eslint-disable-next-line react/prop-types
  const { setRows, setRowModesModel } = props;

  const handleClick = () => {
    // eslint-disable-next-line react/prop-types
    const id = 999999;
    setRows((oldRows) => [
      ...oldRows,
      {
        id,
        driver: { id: 1 },
        trailer: { id: 1 },
        truck: { id: 1 },
        isNew: true,
      },
    ]);
    setRowModesModel((oldModel) => ({
      ...oldModel,
      [id]: { mode: GridRowModes.Edit, fieldToFocus: "truck_plate" },
    }));
  };

  return (
    <Grid container spacing={2}>
      <Grid xs={8} md={8}>
        <GridToolbarContainer>
          <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
            új jármű
          </Button>
        </GridToolbarContainer>
      </Grid>
      <Grid xs={4} md={4}>
        <GridToolbarQuickFilter />
      </Grid>
    </Grid>
  );
}

export default DetailedShiftBox;
