<script>
export default {
  data() {
    return {
      AssigneeCho: ["Choose", "Recent1", "Recent2"],
      Tagtodo: ["Select", "Onhold", "Onhold"],
      TagtodoOne: ["Select", "High", "Medium", "Low"],
      StatOne: ["Select", "Recent1", "Recent2"],
      EditAssigneeCho: ["Choose", "Recent1", "Recent2"],
      EditTagtodo: ["Select", "Onhold", "Onhold"],
      EditTagtodoOne: ["Select", "High", "Medium", "Low"],
      EditStatOne: ["Select", "Recent1", "Recent2"],
    };
  },
};
</script>
<template>
  <!-- Add Note -->
  <div class="modal fade" id="note-units">
    <div class="modal-dialog modal-dialog-centered custom-modal-two">
      <div class="modal-content">
        <div class="page-wrapper-new p-0">
          <div class="content">
            <div class="modal-header border-0 custom-modal-header">
              <div class="page-title">
                <h4>Add Todo</h4>
              </div>
              <button
                type="button"
                class="close"
                data-bs-dismiss="modal"
                aria-label="Close"
              >
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body custom-modal-body">
              <form>
                <div class="row">
                  <div class="col-12">
                    <div class="mb-3">
                      <label class="form-label">Todo Title</label>
                      <input type="text" class="form-control" />
                    </div>
                  </div>
                  <div class="col-12">
                    <div class="mb-3">
                      <label class="form-label">Assignee</label>
                      <vue-select
                        :options="AssigneeCho"
                        id="assigncho"
                        placeholder="Choose"
                      />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="mb-3">
                      <label class="form-label">Tag</label>
                      <vue-select :options="Tagtodo" id="tagtodo" placeholder="Select" />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="mb-3">
                      <label class="form-label">Priority</label>
                      <vue-select
                        :options="TagtodoOne"
                        id="tagtodoone"
                        placeholder="Select"
                      />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="input-blocks todo-calendar">
                      <label class="form-label">Due Date</label>
                      <div class="input-groupicon calender-input">
                        <input
                          type="text"
                          class="form-control date-range bookingrange"
                          placeholder="Select"
                          value="13 Aug 1992"
                        />
                      </div>
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="mb-3">
                      <label class="form-label">Status</label>
                      <vue-select :options="StatOne" id="statone" placeholder="Select" />
                    </div>
                  </div>
                  <div class="col-lg-12">
                    <div class="mb-3 summer-description-box notes-summernote">
                      <label class="form-label">Descriptions</label>
                      <div id="summernote"></div>
                      <p>Maximum 60 Characters</p>
                    </div>
                  </div>
                </div>
                <div class="modal-footer-btn">
                  <button
                    type="button"
                    class="btn btn-cancel me-2"
                    data-bs-dismiss="modal"
                  >
                    Cancel
                  </button>
                  <button type="submit" class="btn btn-submit">Submit</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- /Add Note -->

  <!-- Edit Note -->
  <div class="modal fade" id="edit-note-units">
    <div class="modal-dialog modal-dialog-centered custom-modal-two">
      <div class="modal-content">
        <div class="page-wrapper-new p-0">
          <div class="content">
            <div class="modal-header border-0 custom-modal-header">
              <div class="page-title">
                <h4>Todo Title</h4>
              </div>
              <div class="edit-note-head d-flex align-items-center">
                <a href="javascript:void(0);" class="me-2">
                  <span>
                    <i data-feather="trash-2"></i>
                  </span>
                </a>
                <a href="javascript:void(0);" class="me-2">
                  <span>
                    <i data-feather="star"></i>
                  </span>
                </a>
                <a href="javascript:void(0);" class="me-2">
                  <span>
                    <i data-feather="eye"></i>
                  </span>
                </a>
                <button
                  type="button"
                  class="close"
                  data-bs-dismiss="modal"
                  aria-label="Close"
                >
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
            </div>
            <div class="modal-body custom-modal-body">
              <form>
                <div class="row">
                  <div class="col-12">
                    <div class="input-blocks">
                      <label class="form-label">Note Title</label>
                      <input
                        type="text"
                        class="form-control"
                        placeholder="Meet Lisa to discuss project details"
                      />
                    </div>
                  </div>
                  <div class="col-12">
                    <div class="input-blocks">
                      <label class="form-label">Assignee</label>
                      <vue-select
                        :options="EditAssigneeCho"
                        id="assigncho"
                        placeholder="Choose"
                      />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="input-blocks">
                      <label class="form-label">Tag</label>
                      <vue-select
                        :options="EditTagtodo"
                        id="tagtodo"
                        placeholder="Select"
                      />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="input-blocks">
                      <label class="form-label">Priority</label>
                      <vue-select
                        :options="EditTagtodoOne"
                        id="tagtodoone"
                        placeholder="Select"
                      />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="input-blocks todo-calendar">
                      <label class="form-label">Due Date</label>
                      <div class="input-groupicon calender-input">
                        <input
                          type="text"
                          class="form-control date-range bookingrange"
                          placeholder="Select"
                          value="13 Aug 1992"
                        />
                      </div>
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="input-blocks">
                      <label class="form-label">Status</label>
                      <vue-select
                        :options="EditStatOne"
                        id="statone"
                        placeholder="Select"
                      />
                    </div>
                  </div>
                  <div class="col-lg-12">
                    <div class="input-blocks summer-description-box notes-summernote">
                      <label class="form-label">Descriptions</label>
                      <div id="summernote2"></div>
                      <p>Maximum 60 Characters</p>
                    </div>
                  </div>
                </div>
                <div class="modal-footer-btn">
                  <button
                    type="button"
                    class="btn btn-cancel me-2"
                    data-bs-dismiss="modal"
                  >
                    Cancel
                  </button>
                  <button type="submit" class="btn btn-submit">Save Changes</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- /Edit Note -->

  <!-- Delete Note -->
  <div class="modal fade" id="delete-note-units">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="page-wrapper-new p-0">
          <div class="content">
            <div class="delete-popup">
              <div class="delete-image text-center mx-auto">
                <img
                  src="@/assets/img/icons/close-circle.png"
                  alt="Img"
                  class="img-fluid"
                />
              </div>
              <div class="delete-heads">
                <h4>Are You Sure?</h4>
                <p>
                  Do you really want to delete this item, This process cannot be undone.
                </p>
              </div>
              <div class="modal-footer-btn delete-footer">
                <a href="" class="btn btn-cancel me-2" data-bs-dismiss="modal">Cancel</a>
                <a href="" class="btn btn-submit">Delete</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- /Delete Note -->

  <!-- View Note -->
  <div class="modal fade" id="view-note-units">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="page-wrapper-new p-0">
          <div class="content">
            <div class="modal-header border-0 custom-modal-header">
              <div class="page-title edit-page-title">
                <h4>Todo</h4>
                <p>Personal</p>
              </div>
              <div class="edit-noted-head d-flex align-items-center">
                <a href="javascript:void(0);">
                  <span>
                    <i data-feather="trash-2"></i>
                  </span>
                </a>
                <a href="javascript:void(0);" class="me-2">
                  <span>
                    <i data-feather="star"></i>
                  </span>
                </a>
                <button
                  type="button"
                  class="close"
                  data-bs-dismiss="modal"
                  aria-label="Close"
                >
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
            </div>
            <div class="modal-body custom-modal-body">
              <div class="row">
                <div class="col-12">
                  <div class="edit-head-view">
                    <h6>Meet Lisa to discuss project details</h6>
                    <p>
                      Hiking is a long, vigorous walk, usually on trails or footpaths in
                      the countryside. Walking for pleasure developed in Europe during the
                      eighteenth century. Religious pilgrimages have existed much longer
                      but they involve walking long distances for a spiritual purpose
                      associated with specific religions and also we achieve inner peace
                      while we hike at a local park.
                    </p>

                    <p class="badged high"><i class="fas fa-circle"></i> High</p>
                  </div>
                  <div class="modal-footer-btn edit-footer-menu">
                    <a href="" class="btn btn-cancel me-2" data-bs-dismiss="modal"
                      >Close</a
                    >
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- /View Note -->
  <div class="customizer-links" id="setdata">
    <ul class="sticky-sidebar">
      <li class="sidebar-icons">
        <a
          href="#"
          class="navigation-add"
          data-bs-toggle="tooltip"
          data-bs-placement="left"
          data-bs-original-title="Theme"
        >
          <i data-feather="settings" class="feather-five"></i>
        </a>
      </li>
    </ul>
  </div>
</template>
