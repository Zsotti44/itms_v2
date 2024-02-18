import { useState, useEffect } from "react";
import {
  GridToolbarContainer,
  GridToolbarQuickFilter,
  DataGrid,
  GridRowModes,
  GridActionsCellItem,
  GridRowEditStopReasons,
} from "@mui/x-data-grid";
import Box from "@mui/material/Box";
import {
  getShifts,
  getDispatcherSelectOptions,
  newShift,
} from "../../controllers/shiftController";
import Grid from "@mui/material/Unstable_Grid2"; // Grid version 2
import dayjs from "dayjs";
import DetailedShiftBox from "./Components/DetailedShiftBox";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
//import DeleteIcon from "@mui/icons-material/DeleteOutlined";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Close";

const Shifts = () => {
  const [Shifts, setShifts] = useState([]);
  const [Error, setError] = useState(false);
  const [rowSelectionModel, setRowSelectionModel] = useState(0);
  const [DispatcherSelectOptions, setDispatcherSelectOptions] = useState([]);
  const [rowModesModel, setRowModesModel] = useState({});

  useEffect(() => {
    getShifts()
      .then((data) => {
        if (data.success) setShifts(data.data);
        else setError(true);
      })
      .catch((error) => {
        console.error(error);
        setError(true);
      });

    getDispatcherSelectOptions()
      .then((data) => {
        if (data.success) setDispatcherSelectOptions(data.data);
        else setError(true);
      })
      .catch((error) => {
        console.error(error);
        setError(true);
      });
  }, []);

  dayjs().locale("hu").format("YYYY/MM/DD");

  const EditToolbar = () => {
    const handleClick = () => {
      // eslint-disable-next-line react/prop-types
      const id = -1;
      setShifts((oldRows) => [
        {
          id,
          shift_id: "",
          startDateTime: "",
          endDateTime: "",
          trucks: 0,
          dispatcher: { id: 1 },
          isNew: true,
        },
        ...oldRows,
      ]);
      setRowModesModel((oldModel) => ({
        ...oldModel,
        [id]: { mode: GridRowModes.Edit, fieldToFocus: "dispatcher" },
      }));
    };

    return (
      <Grid container spacing={2}>
        <Grid xs={8} md={8}>
          <GridToolbarContainer>
            <Button
              color="primary"
              startIcon={<AddIcon />}
              onClick={handleClick}
            >
              új shift
            </Button>
          </GridToolbarContainer>
        </Grid>
        <Grid xs={4} md={4}>
          <GridToolbarQuickFilter />
        </Grid>
      </Grid>
    );
  };

  const Shiftcolumns = [
    { field: "id", headerName: "ID", width: 75, editable: false },
    { field: "shift_id", headerName: "Műszak ID", width: 150, editable: false },
    {
      field: "startDateTime",
      headerName: "Kezdete",
      width: 200,
      editable: false,
    },
    {
      field: "endDateTime",
      headerName: "Kezdete",
      width: 200,
      editable: false,
    },
    { field: "trucks", headerName: "Kamionok", width: 150, editable: false },
    {
      field: "dispatcher",
      headerName: "Diszpécser",
      width: 150,
      editable: true,
      type: "singleSelect",
      valueGetter: (params) => {
        return params.row.dispatcher.id;
      },
      getOptionValue: (value) => value.id,
      getOptionLabel: (value) => value.name,
      valueOptions: DispatcherSelectOptions,
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
      },
    },
  ];
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

    const editedRow = Shifts.find((row) => row.id === id);
    if (editedRow.isNew) {
      setShifts(Shifts.filter((row) => row.id !== id));
    }
  };
  const processRowUpdate = (newRow) => {
    var request = {};
    request.dispatcherId = 1;
    request.trucks = [{ truck: 0, trailer: 0, driver: 0, shiftid: 0 }];
    request.startDateTime = "2024-02-04T15:09:17.733904";
    request.shift_id = "";
    if (newRow.isNew) {
      newShift(request).then((data) => {
        setShifts(data.data);
        console.log(data.data);
      });
    } else {
      /* EditSift(request).then((data) => {
        setRows(data.data.trucks);
      });*/
    }

    const updatedRow = { ...newRow, isNew: false };
    return updatedRow;
  };
  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };
  return (
    <>
      {Error ? (
        <h1>Hiba!</h1>
      ) : (
        <>
          <Box
            sx={{
              height: 350,
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
              rows={Shifts}
              columns={Shiftcolumns}
              editMode="row"
              slots={{ toolbar: EditToolbar }}
              slotProps={{
                toolbar: { showQuickFilter: true, setShifts, setRowModesModel },
              }}
              onRowSelectionModelChange={(newRowSelectionModel) =>
                setRowSelectionModel(newRowSelectionModel)
              }
              rowSelectionModel={rowSelectionModel}
              rowModesModel={rowModesModel}
              onRowModesModelChange={handleRowModesModelChange}
              onRowEditStop={handleRowEditStop}
              processRowUpdate={processRowUpdate}
            />
          </Box>
          <br></br>

          {rowSelectionModel == 0 ? (
            <h3>Válassz ki egy műszakot az információk megjelenítéséhez!</h3>
          ) : (
            <DetailedShiftBox id={rowSelectionModel} />
          )}
        </>
      )}
    </>
  );
};
export default Shifts;
